﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tienda.Interfaces;
using TiendaWeb.Models;

namespace TiendaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // ---------------------------------------- Post User Login ----------------------------------------
        // POST: api/<Product>
        [HttpPost("login")]
        public ActionResult Post([FromQuery] string username, string password, [FromServices] IUsersLogic userLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Guest)
            {

                try
                {
                    string[] key = new string[] { };
                    key = userLogic.UserTryLogin(username);
                    string[] newSession = new string[2];
                    var hash = new Tienda.Logic.DataHashing();
                    for (var i = 0; i < key.Length; i++)
                    {
                        newSession = userLogic.UserLogin(username, hash.ComputeHash(password, key[i]));
                        if (newSession[0] != "" && newSession[1] != "") {
                            Program.NewSession(new Tienda.Logic.UserLogic(new Tienda.Dto.UserSession() { SessionToken = new Guid().ToString(), SessionType = userLogic.ValidateUserType(username) }, newSession[1]));
                        }
                    }
                    if (newSession[0] == "" || newSession[1] == "")
                    {
                        throw new Exception();
                    }
                } catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok("Bienvenid@ " + username);

            }
            else
            {
                return BadRequest("Ya iniciaste sesión" + Program.RetrieveSession().RetrieveUser().Username);

            }
        }

        // ---------------------------------------- Post User Signup ----------------------------------------
        // POST: api/<User>
        [HttpPost("signup")]
        public ActionResult Post([FromQuery] string Username, string Name, string LastName, int DNI, string PhoneNumber, string Password, [FromServices] IUsersLogic userLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Guest)
            {

                try
                {
                    var hash = new Tienda.Logic.DataHashing();
                    string newSalt = hash.GenerateSalt();
                    string hPassword = hash.ComputeHash(Password, newSalt);

                    var newUserData = new Tienda.Dto.User() { Username = Username, Name = Name, LastName = LastName, DNI = DNI, PhoneNumber = PhoneNumber };

                    //var newUserData = new User() { Username = username, 
                    //                               Name = name,
                    //                               LastName = lastname,
                    //                               DNI = dni, 
                    //                               PhoneNumber = phonenumber,
                    //                               CreationDate = DateTime.Now } ;
                    userLogic.UserSignup(newUserData, hPassword, newSalt);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();

            }
            else
            {
                return BadRequest("Ya tenés cuenta" + userLogic.RetrieveSession().SessionType);

            }
        }


        // ---------------------------------------- Get Users List ----------------------------------------
        // GET: api/<User>
        [HttpGet("clientes/token")]
        public ActionResult<IEnumerable<UserForList>> GetUsersList([FromServices] IUsersLogic userLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Staff)
            {

                try
                {
                    var usersList = userLogic.ListUsers();
                    return Ok(usersList);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Guest)
                    return BadRequest("Iniciá sesión y ahí vemos\n" + userLogic.RetrieveSession().SessionType);
                else
                    return BadRequest("No tenés permiso     " + userLogic.RetrieveSession().SessionType);
            }
        }


        // ---------------------------------------- Get User Info ----------------------------------------
        // GET: api/<User>
        [HttpGet("cuenta/token")]
        public ActionResult<UserForList> GetUserInfo([FromServices] IUsersLogic userLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType != Tienda.Dto.UserTypes.Guest)
            {

                try
                {
                    //Token de Sesión daría lugar a transportar información de manera sutil
                    //Por ahora la info que viaja es el UserID
                    var userInfo = userLogic.DisplayUserInfo(Program.RetrieveSession().RetrieveUser().Username);
                    return Ok(new UserForList(/*(int)userInfo.UserID,*/ userInfo.Username, userInfo.Name, userInfo.LastName, userInfo.DNI, userInfo.PhoneNumber, userInfo.CreationDate));
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                return BadRequest("Iniciá sesión y ahí vemos\n" + userLogic.RetrieveSession().SessionType);

            }
        }

        // ---------------------------------------- Get User Password ----------------------------------------
        // GET: api/<User>
        [HttpGet("cuenta/forgotpassword")]
        public ActionResult<UserForList> Get([FromServices] IUsersLogic userLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType != Tienda.Dto.UserTypes.Guest)
            {

                try
                {

                    return Ok("Contraseña: " + Program.RetrieveSession().DontDoThisAtHome(Program.RetrieveSession().RetrieveUser().Username));
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                return BadRequest("Iniciá sesión y ahí vemos\n" + userLogic.RetrieveSession().SessionType);

            }
        }

        // GET api/<Product>/5
        [HttpGet("configuracion")]
        public ActionResult ChangePassword([FromQuery] string oldPassword, string newPassword, [FromServices] IUsersLogic userLogic)
        {
            if (Program.RetrieveSession().RetrieveSession().SessionType != Tienda.Dto.UserTypes.Guest)
            {

                try
                {
                    string passwordHash = ""; 
                    var hash = new Tienda.Logic.DataHashing();
                    string newSalt = hash.GenerateSalt();
                    string hPassword = hash.ComputeHash(newPassword, newSalt);
                    string key = userLogic.UserTryLogin(Program.RetrieveSession().userData.Username)[0];
                    if (userLogic.ComparePassword(Program.RetrieveSession().userData.Username, hash.ComputeHash(oldPassword, key))) 
                    {
                        /* ¯\_(ツ)_ /¯ */ passwordHash = userLogic.UpdateUserPassword(Program.RetrieveSession().userData.Username, hash.ComputeHash(newPassword, newSalt), newSalt);
                        return Ok("Contraseña nueva: " + passwordHash);
                    }
                    
                    if (passwordHash != "")
                    {
                        return Ok("Contraseña nueva: " + passwordHash);
                    }
                    else
                        return BadRequest("Contraseña Incorrecta");
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                return BadRequest("Iniciá sesión y ahí vemos\n" + userLogic.RetrieveSession().SessionType);

            }
        }

        //DELETE SignOut
        [HttpDelete("signout")]
        public ActionResult SignOut()
        {
                if ( Program.RetrieveSession().RetrieveSession().SessionType != Tienda.Dto.UserTypes.Guest)
                {
                    Program.NewSession(new Tienda.Logic.UserLogic());
                    return Ok("Nos vemossss");
                } else
                {
                    return BadRequest("¿De dónde querés salir sin cuenta?");
                }
        }

    }
}
