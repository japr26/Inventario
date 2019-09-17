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
    public class HomeController : Controller
    {
        //localhost/home

        private Inventario inventario = new Inventario();
        private Almacen_Articulo almacen_Articulo = new Almacen_Articulo();
        private Articulo articulo = new Articulo();
        private Almacen almacen = new Almacen();
        private Transacciones transacciones = new Transacciones();
 
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Inventario> lista = new List<Inventario>();
            IPagedList<Inventario> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = inventario.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Transacciones(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Transacciones> lista = new List<Transacciones>();
            IPagedList<Transacciones> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = transacciones.Listar();
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Articulos(int id, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            List<Almacen_Articulo> lista = new List<Almacen_Articulo>();
            IPagedList<Almacen_Articulo> stu = null;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            lista = almacen_Articulo.Obtener(id);
            stu = lista.ToPagedList(pageIndex, pageSize);

            return View(stu);
        }

        public ActionResult Crud()
        {
            ViewBag.articulo = articulo.Listar();
            ViewBag.almacen = almacen.Listar();

            return View(new Almacen_Articulo());
        }

        public ActionResult Guardar(Almacen_Articulo model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();

                return Redirect("~/Home");
            }
            else
            {
                ViewBag.articulo = articulo.Listar();
                ViewBag.almacen = almacen.Listar();

                return View("~/Views/Home/Crud.cshtml", model);
            }

        }

        public ActionResult Entrada(int id, int id2)
        {

            return View(almacen_Articulo.Obtener2(id, id2));
        }

        public ActionResult Salida(int id, int id2)
        {
            return View(almacen_Articulo.Obtener2(id, id2)
);
        }

        public ActionResult Entrar(Almacen_Articulo model)
        {

            model.Entrar();

            return Redirect("~/Home/Articulos/"+model.ArticuloId);
        }

        public ActionResult Sacar(Almacen_Articulo model)
        {

            model.Sacar();

            return Redirect("~/Home/Articulos/" + model.ArticuloId);
        }

    }
}