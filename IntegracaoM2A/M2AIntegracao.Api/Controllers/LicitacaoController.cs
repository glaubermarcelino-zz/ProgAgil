using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using M2AIntegracao.Api.Dtos;
using M2AIntegracao.Domain.Identity;

namespace M2AIntegracao.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LicitacaoController : ControllerBase
    {

    }
}