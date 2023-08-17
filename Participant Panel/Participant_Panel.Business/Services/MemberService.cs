using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Participant_Panel.Business.Extensions;
using Participant_Panel.Business.Helpers;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Common.Enums;
using Participant_Panel.Common.ResponseObjects;
using Participant_Panel.DataAccess.UnitOfWork;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;


namespace Participant_Panel.Business.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<MemberCreateDto> _createValidator;
        private readonly IValidator<MemberUpdateDto> _updateValidator;
        private readonly IWebHostEnvironment _environment;

        public MemberService(IUow uow, IMapper mapper, IValidator<MemberCreateDto> createValidator,IValidator<MemberUpdateDto> updateValidator,IWebHostEnvironment environment)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _environment = environment;
        }

        public async Task<IResponse<List<MemberListDto>>> GetAllAsync()
        {
            List<MemberListDto> memberListDtos = _mapper.Map<List<MemberListDto>>(await _uow.GetRepository<AppUser>().GetAllAsync());
            return new Response<List<MemberListDto>>(ResponseType.Success, memberListDtos);
        }

        public IQueryable<AppUser> GetQueryable()
        {
            return _uow.GetRepository<AppUser>().GetQuery().Include(x => x.Department);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(string id)
        {
            var dto = _mapper.Map<IDto>(await _uow.GetRepository<AppUser>().GetByFilter(x => x.Id==id));
            if (dto is null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"No data found matching {id}");
            }
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse<MemberCreateDto>> CreateAsync(MemberCreateDto memberCreateDto)
        {
            ValidationResult validationResult = _createValidator.Validate(memberCreateDto);

            if (!validationResult.IsValid) return new Response<MemberCreateDto>(ResponseType.ValidationError, memberCreateDto, validationResult.ConvertToCustomValidationError());

            AppUser appUser = _mapper.Map<AppUser>(memberCreateDto);
            if (memberCreateDto.ImageFile is not null)
            {

            appUser.ImageName=FileManager.SaveFile(_environment.WebRootPath,"uploads/member",memberCreateDto.ImageFile);
            }

            await _uow.GetRepository<AppUser>().CreateAsync(appUser);
            await _uow.SaveChangesAsync();
            return new Response<MemberCreateDto>(ResponseType.Success, memberCreateDto);
        }


        public async Task<IResponse<MemberUpdateDto>> UpdateAsync(MemberUpdateDto memberUpdateDto)
        {
            ValidationResult validationResult = _updateValidator.Validate(memberUpdateDto);
            if (!validationResult.IsValid) return new Response<MemberUpdateDto>(ResponseType.ValidationError, memberUpdateDto, validationResult.ConvertToCustomValidationError());

            AppUser unchangedMember = await _uow.GetRepository<AppUser>().GetById(memberUpdateDto.Id);
            if(unchangedMember is null) return new Response<MemberUpdateDto>(ResponseType.NotFound, $"No data found matching {memberUpdateDto.Id}");

            if (memberUpdateDto.ImageFile is not null)
            {
                if (memberUpdateDto.ImageFile.ContentType != "image/jpeg" && memberUpdateDto.ImageFile.ContentType != "image/png")
                {
                    return new Response<MemberUpdateDto>(ResponseType.ValidationError, memberUpdateDto, validationResult.ConvertToCustomValidationError());
                }
                if (memberUpdateDto.ImageFile.Length > 2097152)
                {
                    return new Response<MemberUpdateDto>(ResponseType.ValidationError, memberUpdateDto, validationResult.ConvertToCustomValidationError());
                }
                if (unchangedMember.ImageName != null)
                {

                    FileManager.DeleteFile(_environment.WebRootPath, "uploads/member", unchangedMember.ImageName);
                }
                memberUpdateDto.ImageName = FileManager.SaveFile(_environment.WebRootPath, "uploads/member", memberUpdateDto.ImageFile);
            }
            _uow.GetRepository<AppUser>().Update(_mapper.Map<AppUser>(memberUpdateDto), unchangedMember);
            await _uow.SaveChangesAsync();
            return new Response<MemberUpdateDto>(ResponseType.Success, memberUpdateDto);

        }

        public async Task<IResponse> RemoveAsync(string id)
        {
            AppUser removedMember = await _uow.GetRepository<AppUser>().GetByFilter(x => x.Id == id);
            if(removedMember is null) return new Response($"No data found matching {id}", ResponseType.NotFound);

            FileManager.DeleteFile(_environment.WebRootPath, "uploads/member", removedMember.ImageName);
            _uow.GetRepository<AppUser>().Remove(removedMember);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }
    }
}
