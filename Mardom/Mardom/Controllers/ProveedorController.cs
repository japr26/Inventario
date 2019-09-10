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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        private Proveedor proveedor = new Proveedor();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Proveedor> lista = new List<Proveedor>();
            IPagedList<Proveedor> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = proveedor.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Ver(int id)
        {
            return View(proveedor.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {

            return View(
                id == 0 ? new Proveedor() : proveedor.Obtener(id)
            );
        }

        public ActionResult Guardar(Proveedor model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Proveedor");
            }
            else
            {
                return View("~/Views/Proveedor/Crud.cshtml", model);
            }

        }

        public ActionResult Eliminar(int id)
        {
            proveedor.Id = id;
            proveedor.Eliminar();

            return Redirect("~/Proveedor");
        }
    }
}