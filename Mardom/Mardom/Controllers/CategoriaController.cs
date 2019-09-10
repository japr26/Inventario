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
    public class CategoriaController : Controller
    {
        // GET: Categoria

        private Categoria categoria = new Categoria();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Categoria> lista = new List<Categoria>();
            IPagedList<Categoria> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = categoria.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Ver(int id)
        {
            return View(categoria.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {

            return View(
                id == 0 ? new Categoria() : categoria.Obtener(id)
            );
        }

        public ActionResult Guardar(Categoria model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Categoria");
            }
            else
            {
                return View("~/Views/Categoria/Crud.cshtml", model);
            }

        }

        public ActionResult Eliminar(int id)
        {
            categoria.Id = id;
            categoria.Eliminar();

            return Redirect("~/Categoria");
        }
    }
}