using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ProductoController : Controller
    {
        // Vista principal
        public ActionResult Index()
        {
            return View();
        }

        // Listar todos los productos
        public JsonResult Listar()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities())
            {
                listaProductos = db.Producto.ToList();
            }

            return Json(new { data = listaProductos }, JsonRequestBehavior.AllowGet);
        }

        // Obtener un producto por ID
        public JsonResult Obtener(int id)
        {
            Producto producto = new Producto();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities())
            {
                producto = db.Producto.FirstOrDefault(x => x.id == id);
            }

            return Json(producto, JsonRequestBehavior.AllowGet);
        }

        // Guardar o actualizar producto
        [HttpPost]
        public JsonResult Guardar(Producto producto)
        {
            bool respuesta = true;

            try
            {
                using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                {
                    if (producto.id == 0)
                    {
                        // Nuevo producto
                        db.Producto.Add(producto);
                    }
                    else
                    {
                        // Actualizar producto existente
                        Producto productoExistente = db.Producto.FirstOrDefault(p => p.id == producto.id);

                        if (productoExistente != null)
                        {
                            productoExistente.nombre = producto.nombre;
                            productoExistente.descripcion = producto.descripcion;
                            productoExistente.precio = producto.precio;
                            productoExistente.cantidad = producto.cantidad;
                        }
                    }

                    db.SaveChanges();
                }
            }
            catch
            {
                respuesta = false;
            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar producto por ID
        public JsonResult Eliminar(int id)
        {
            bool respuesta = true;

            try
            {
                using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                {
                    Producto producto = db.Producto.FirstOrDefault(p => p.id == id);

                    if (producto != null)
                    {
                        db.Producto.Remove(producto);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                respuesta = false;
            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}
