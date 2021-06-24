using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tienda.Interfaces;
using TiendaWeb.Models;



namespace TiendaWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {



        // ---------------------------------------- GET Product Paginated ----------------------------------------
        // GET: api/<Product>
        [HttpGet("catalogo")]
        public ActionResult<IEnumerable<ProductForList>> GetPaginated([FromQuery] int index, int fetch, [FromServices] IProductLogic productLogic)
        {
            var products = productLogic.GetProductsPaginated(index, fetch);
            return Ok(products);
        }

        // ---------------------------------------- GET Product Filtered ----------------------------------------
        // GET: api/<Product>
        [HttpGet("catalogo/filtros")]
        public ActionResult<IEnumerable<ProductForList>> Get([FromQuery] ProductFilter filters, int index, int fetch, [FromServices] IProductLogic productLogic)
        {
            var products = new List<Tienda.Dto.Product>();
            string[] filtering = { filters.Category.ToString(), filters.Price.ToString(), filters.Status.ToString() };
            if (filtering[0] == "" &&
                filtering[1] == "" &&
                filtering[2] == "")
            {
                products = productLogic.GetProductsPaginated(index, fetch);
                
            }
            else
            {
                products = productLogic.GetProductsFiltered(filtering, index, fetch);
            }
            if (products.Count < 1)
                return BadRequest();
            return Ok(products);
        }

        // ---------------------------------------- GET Product By ID ----------------------------------------
        // GET api/<Product>/5
        [HttpGet("buscarautom")]
        public ActionResult<ProductForList> Get([FromQuery] int id, [FromServices] IProductLogic productLogic)
        {
            var product = productLogic.GetProductByID(id);
            if (product == null)
                return NotFound();

            return Ok(new ProductForList((int)product.ProductID, product.Name, product.Description, (decimal)product.Price, product.CategoryID, product.StatusID));

        }

        // ---------------------------------------- GET Product By Name ----------------------------------------
        // GET api/<Product>/5
        [HttpGet("buscar")]
        public ActionResult<IEnumerable<ProductForList>> Get([FromQuery] string name, [FromServices] IProductLogic productLogic)
        {
            var products = productLogic.GetProductByName(name);
            if (products == null)
                    return NotFound();

            return Ok(products);


        }

        // ---------------------------------------- POST New Product ----------------------------------------
        // POST api/<Product>
        [HttpPost("alta")]
        public ActionResult<int> Post([FromBody] ProductBase product, [FromServices] IProductLogic productLogic)
        {
            
            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Staff) {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var newProduct = productLogic.CreateProduct(new Tienda.Dto.Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.Value,
                    CategoryID = product.CategoryID,
                    StatusID = product.StatusID
                });
                return Ok("Producto añadido");
            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Customer)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }

        }

        // ---------------------------------------- PUT Update Product ----------------------------------------
        // PUT api/<Product>/5
        [HttpPut("modificar")]
        public ActionResult Put([FromBody] ProductBase product, [FromQuery] int id, [FromServices] IProductLogic productLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Staff)
            {

                try
                {
                productLogic.UpdateProduct(new Tienda.Dto.Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.Value,
                    CategoryID = product.CategoryID,
                    StatusID = product.StatusID
                }, id);

                return Ok("Producto Modificado");
            } catch (Exception e)
            {
                return BadRequest(e);
            }
            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Customer)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }
                
        }

        // ---------------------------------------- DELETE Delete Product ----------------------------------------
        // DELETE api/<Product>/5
        [HttpDelete("eliminar")]
        public ActionResult Delete(int id, [FromServices] IProductLogic productLogic)
        {

            if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Staff)
            {

                try
                {
                    var borrado = productLogic.DeleteProduct(id);
                    //if (borrado != null)
                        return Ok("Producto Eliminado");
                    //else
                        //return NotFound("No se pudo eliminar: No se encontró");
            }
            catch (Exception e)
            {
                return BadRequest(e);
                }
            }

            else
            {
                if (Program.RetrieveSession().RetrieveSession().SessionType == Tienda.Dto.UserTypes.Customer)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }
        }
    }
}
