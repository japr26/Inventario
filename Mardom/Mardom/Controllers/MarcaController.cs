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
    public class MarcaController : Controller
    {
        // GET: Marca
        private Marca marca = new Marca();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Marca> lista = new List<Marca>();
            IPagedList<Marca> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = marca.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Ver(int id)
        {
            return View(marca.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {

            return View(
                id == 0 ? new Marca() : marca.Obtener(id)
            );
        }

        public ActionResult Guardar(Marca model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Marca");
            }
            else
            {
                return View("~/Views/Marca/Crud.cshtml", model);
            }

        }

        public ActionResult Eliminar(int id)
        {
            marca.Id = id;
            marca.Eliminar();

            return Redirect("~/Marca");
        }
    }
}