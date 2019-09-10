using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mardom.Models;
using PagedList;

namespace Mardom.Controllers
{
    [HandleError(View = "Error")]
    public class ArticuloController : Controller
    {
        //localhost/views/Articulo

        private Articulo articulo = new Articulo();
        private Categoria categoria = new Categoria();
        private Marca marca = new Marca();
        private Proveedor proveedor = new Proveedor();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Articulo> lista = new List<Articulo>();
            IPagedList<Articulo> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = articulo.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Ver(int id)
        {
            return View(articulo.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.Categorias = categoria.Listar();
            ViewBag.Marcas = marca.Listar();
            ViewBag.Proveedor = proveedor.Listar();

            return View(
                id == 0 ? new Articulo() : articulo.Obtener(id)
            );
        }

        public ActionResult Guardar(Articulo model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Articulo");
            }
            else
            {
                return View("~/Views/Articulo/Crud.cshtml", model);
            }

        }

        public ActionResult Eliminar(int id)
        {
            articulo.Id = id;
            articulo.Eliminar();

            return Redirect("~/Articulo");
        }

    }
}