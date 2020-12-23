using AutoMapper;
using RealPage.Properties.Application.DTO;
using RealPage.Properties.Application.Interface;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Domain.Interface;
using RealPage.Properties.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PropertiesApplication> _logger;
        
        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, IAppLogger<PropertiesApplication> logger)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _logger = logger;
        }
        public async Task<Response<UsersDto>> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacios.";
                return response;
            }
            try
            {
                var user = await _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Add(UsersDto userDto)
        {
            var response = new Response<bool>();
            try
            {
                var user = _mapper.Map<User>(userDto);
                response.Data = await _usersDomain.Add(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(UsersDto userDto)
        {
            var response = new Response<bool>();
            try
            {
                var user = _mapper.Map<User>(userDto);
                response.Data = await _usersDomain.Update(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(int userId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _usersDomain.Delete(userId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<UsersDto>> Get(int userId)
        {
            var response = new Response<UsersDto>();
            try
            {
                var user = await _usersDomain.Get(userId);
                response.Data = _mapper.Map<UsersDto>(user);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<UsersDto>>> GetAll()
        {
            var response = new Response<IEnumerable<UsersDto>>();
            try
            {
                var user = await _usersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<UsersDto>>(user);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                    _logger.LogInformation("Successful consultation!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
