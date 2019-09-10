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
    public class AlmacenController : Controller
    {
        // GET: Almacen

        private Almacen almacen = new Almacen();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Almacen> lista = new List<Almacen>();
            IPagedList<Almacen> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = almacen.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Ver(int id)
        {
            return View(almacen.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {

            return View(
                id == 0 ? new Almacen() : almacen.Obtener(id)
            );
        }

        public ActionResult Guardar(Almacen model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Almacen");
            }
            else
            {
                return View("~/Views/Almacen/Crud.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            almacen.Id = id;
            almacen.Eliminar();

            return Redirect("~/Almacen");
        }
    }
}