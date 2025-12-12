using System;
using api.DTOs;
using api.Entities;
using api.Interfaces;

namespace api.Extensions;

public static class AppUserExtension
{
  public static UserDto ToDto(this AppUser user, ITokenService tokenService)
    {
      return new UserDto
        {
            Id = user.Id,
            Email=user.Email,
            DisplayName=user.DisplayName,
            Token  = tokenService.CreateToken(user)
        };

    }
}
