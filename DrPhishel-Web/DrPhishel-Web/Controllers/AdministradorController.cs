﻿using DrPhishel_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrPhishel_Web.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View("~/Views/Administrador/Index.cshtml");
        }
        public ActionResult AgregarEspecialidad()
        {
            return View();
        }
        public ActionResult AgregarDoctor()
        {
            return View();
        }
        public ActionResult AgregarPaciente()
        {
            return View();
        }

        [HttpPost]
        /* Se encarga de agregar una especialidad nueva, retorna un estado true si se logro uno false si no */
        public JsonResult AgregarEspecialidadDoctor(string pNombreCategoria)
        {
            Especialidad nuevaEspecialidad = new Especialidad(0,pNombreCategoria); /* Se pone 0 ya que el ID se agrega automaticamente */
            bool agregado = nuevaEspecialidad.agregarCategoria();
            return Json( new { Status = agregado }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        /* Obtiene la lista de cobros de un doctor */
        public JsonResult VerCobrosDoctores()
        {
            List<object> listaCobros = Cobros.verCobros();
            return Json(listaCobros.ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        /* realiza el cobro a un doctor */
        public JsonResult RealizarCobro (int pCostoCita)
        {
            bool cobro = Cobros.RealizarCobro(pCostoCita);
            return Json(new { Status = cobro }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        /* acepta un doctor temporal como permanente*/
        public JsonResult AceptarDoctor(int pNumeroDoctor)
        {
            bool aceptado = Doctor.AceptarDoctor(pNumeroDoctor);
            return Json(new { Status = aceptado }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult VerSolicitudesDoctores()
        {
            List<object> solicitudes =  Doctor.VerSolicitudDoctor();
            return Json(solicitudes.ToList(),JsonRequestBehavior.AllowGet);
        }


    }
}