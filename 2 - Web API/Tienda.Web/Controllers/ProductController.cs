using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Tienda.Dto;
using Tienda.Interfaces;
using Tienda.WebAPI.Models;



namespace TiendaWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {



        // ---------------------------------------- GET Product Paginated ----------------------------------------
        // GET: api/<Product>
        [HttpGet("catalogo")]
        public ActionResult<ProductListResponse> GetPaginated([FromQuery] int index, int fetch, string order, [FromServices] IProductLogic productLogic)
        {
            var productsList = productLogic.GetProductsPaginated(index, fetch, order);
            return Ok(productsList);
        }

        // ---------------------------------------- GET Product Filtered ----------------------------------------
        // GET: api/<Product>
        [HttpGet("catalogo/filtros")]
        public ActionResult<ProductListResponse> Get([FromQuery] ProductFilter filters, int index, int fetch, [FromServices] IProductLogic productLogic)
        {
            var products = new ProductList();
            ProductFilters filtering = new ProductFilters() { Category = (int)filters.Category, PriceMin = (int)filters.PriceMin, PriceMax = (int)filters.PriceMax, Status = (int)filters.Status };
            products = productLogic.GetProductsFiltered(filtering, index, fetch);
            if (products == null)
                return NoContent();
            return Ok(products);
        }

        // ---------------------------------------- GET Product By ID ----------------------------------------
        // GET api/<Product>
        [HttpGet("buscar/id")]
        public ActionResult<ProductForList> Get([FromQuery] int id, [FromServices] IProductLogic productLogic)
        {
            var product = productLogic.GetProductByID(id);
            if (product == null)
                return NotFound();
            var productByID = new ProductForList(     (int)product.Id, 
                                                             product.Name, 
                                                             product.Description, 
                                                    (decimal)product.Price, 
                                                             product.CategoryID, 
                                                             product.StatusID);

            return Ok(productByID);

        }

        // ---------------------------------------- GET Product By Name ----------------------------------------
        // GET api/<Product>/5
        [HttpGet("buscar/name")]
        public ActionResult<ProductListResponse> Get([FromQuery] string name, [FromServices] IProductLogic productLogic)
        {
            var products = productLogic.GetProductByName(name);
            if (products == null)
                    return NotFound();
            return Ok(products);


        }

        // ---------------------------------------- POST New Product ----------------------------------------
        // POST api/<Product>
        [HttpPost("staff/alta")]
        public ActionResult<long> Post([FromBody] ProductToSend product, [FromServices] IProductLogic productLogic)
        {
            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1) {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var newProductId = productLogic.CreateProduct(new Tienda.Dto.ProductForInsert
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryID = product.CategoryID,
                    StatusID = product.StatusID
                });
                return Ok(newProductId);
            }
            else
            {
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }

        }

        // ---------------------------------------- PUT Update Product ----------------------------------------
        // PUT api/<Product>/5
        [HttpPut("staff/modificar")]
        public ActionResult Put([FromBody] ProductBase product, [FromQuery] int id, [FromServices] IProductLogic productLogic)
        {
            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1)
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
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }
                
        }

        // ---------------------------------------- DELETE Delete Product ----------------------------------------
        // DELETE api/<Product>/5
        [HttpDelete("staff/eliminar")]
        public ActionResult Delete(int id, [FromServices] IProductLogic productLogic)
        {
            Program.RetrieveSession().RetrieveSession().UserType = 1; //Breach de la A&A
            if (Program.RetrieveSession().RetrieveSession().UserType == 1)
            {

                try
                {
                    if (productLogic.DeleteProduct(id) == 1)
                        return Ok("Producto Eliminado");
                    else
                        return NotFound();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            else
            {
                if (Program.RetrieveSession().RetrieveSession().UserType == 1)
                    return BadRequest("No tenés permiso para esto");
                else
                    return BadRequest("Iniciá sesión y ahí vemos");
            }
        }
    }
}
