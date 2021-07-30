using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tienda.Interfaces;
using Tienda.WebAPI.Models;

namespace TiendaWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductsCategoryController : ControllerBase
    {

        // ---------------------------------------- GET Categories List ----------------------------------------
        // GET: api/<Categories>
        [HttpGet("lista")]
        public ActionResult<IEnumerable<CategoryForList>> Get([FromServices] IProductsCategoryLogic categoryLogic)
        {
                try
                {
                    var categories = categoryLogic.ListProductsCategories();
                    return Ok(categories);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
        }
        // ---------------------------------------- POST New Category ----------------------------------------
        // POST api/<Product>
        [HttpPost("nueva")]
        public ActionResult<int> Post([FromQuery] string categoryDescription, [FromServices] IProductsCategoryLogic categoryLogic)
        {

            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1)
            {

                try
                {
                    categoryLogic.CreateProductsCategory(categoryDescription);

                    return Ok("Categoría ingresada");

                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                {
                    return BadRequest("Iniciá sesión y ahí vemos\n" + Program.RetrieveSession().RetrieveSession().UserType);
                } else
                {
                    return BadRequest("No tenés permiso     " + Program.RetrieveSession().RetrieveSession().UserType);
                }
            }
        }


        // ---------------------------------------- PUT Update Category ----------------------------------------
        // PUT api/<Product>/5
        [HttpPut("actualizar")]
        public ActionResult Put([FromBody] CategoryBase category, [FromServices] IProductsCategoryLogic categoryLogic)
        {
            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1)
            {

                try
                {
                    categoryLogic.UpdateProductsCategory(new Tienda.Dto.ProductsCategory
                    {
                        Description = category.Description,
                        CategoryID = category.CategoryID
                    });

                    return Ok("Categoría Modificado");
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                {
                    return BadRequest("Iniciá sesión y ahí vemos\n" + Program.RetrieveSession().RetrieveSession().UserType);
                }
                else
                {
                    return BadRequest("No tenés permiso     " + Program.RetrieveSession().RetrieveSession().UserType);
                }
            }
        }

        // ---------------------------------------- DELETE Delete Category ----------------------------------------
        //DELETE api/<Category>
        [HttpDelete("eliminar")]
        public ActionResult Delete([FromQuery] int categoryID, [FromServices] IProductsCategoryLogic categoryLogic)
        {
            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1)
            {

                try
                {
                    categoryLogic.DeleteProductsCategory(categoryID);
                    return Ok("Categoría Eliminada");
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                {
                    return BadRequest("Iniciá sesión y ahí vemos\n" + Program.RetrieveSession().RetrieveSession().UserType);
                }
                else
                {
                    return BadRequest("No tenés permiso     " + Program.RetrieveSession().RetrieveSession().UserType);
                }
            }
        }
    }
}
    
