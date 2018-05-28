using LBP.Web.Models;
using LBP.Web.ViewModels;
using LBP.Web.ViewModels.Jornada;
using LBP.Web.ViewModels.Jugador;
using LBP.Web.ViewModels.Liga;
using LBP.Web.ViewModels.Partido;
using LBP.Web.ViewModels.Presentacion;
using LBP.Web.ViewModels.Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBP.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        #region LOGIN
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel objViewMolel = new LoginViewModel();

            return View(objViewMolel);

        }

        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();

            Usuarios objUsuario = context.Usuarios.FirstOrDefault(X => X.Usuario == objViewModel.Usuario
            && X.Password == objViewModel.password);

            if (objUsuario == null)
            {
                return View(objViewModel);
            }
            else
            {
                ViewBag.Error = "Todos lo campos deben ser llenados por favor";
            }

            //Se insertan los valores necesarios en la tabla sesiones
            LBPEntities contextSesion = new LBPEntities();
            Sesiones objSesion = new Sesiones();

            objSesion.InicioSesion = DateTime.Now;
            objSesion.CierreSesion = DateTime.Now;
            objSesion.UsuarioId = objUsuario.UsuarioId;
            objSesion.RolId = objUsuario.RolId;
            contextSesion.Sesiones.Add(objSesion);
            contextSesion.SaveChanges();

            // se obtiene la una fila para cambiar el estatus del usuario
            Usuarios objUsuarioUpdate = context.Usuarios.FirstOrDefault(X => X.UsuarioId == objUsuario.UsuarioId);
            objUsuarioUpdate.EstatusId = 1;
            context.SaveChanges();

            UsuariosStatica.usuarioId = objUsuario.UsuarioId;
            UsuariosStatica.sesionId = objSesion.SesionId;

            Session["objUsuario"] = objUsuario;

            return RedirectToAction("Dashboard");
        }
        #endregion

        #region DASHBOARD

        [HttpGet]
        public ActionResult Dashboard()
        {
            DashboardViewModel objViewModel = new DashboardViewModel();

            return View(objViewModel);
        }
        #endregion

        #region CERRAR SESION

        public ActionResult CerrarSesion()
        {
            LBPEntities context = new LBPEntities();
            // se obtiene la una fila para cambiar el estatus del usuario
            Usuarios objUsuarioUpdate = context.Usuarios.FirstOrDefault(X => X.UsuarioId == UsuariosStatica.usuarioId);
            objUsuarioUpdate.EstatusId = 2;
            context.SaveChanges();

            //Se obtiene la sesion actual para actualizar la fecha de cierre de sesión
            Sesiones objSesionUpdate = context.Sesiones.FirstOrDefault(X => X.SesionId == UsuariosStatica.sesionId);
            objSesionUpdate.CierreSesion = DateTime.Now;
            context.SaveChanges();

            Session.Clear();
            return RedirectToAction("Login");
        }
        #endregion

        #region USUARIO


        [HttpGet]
        public ActionResult LstUsuarios()
        {
            LstUsuariosViewModel objViewModel = new LstUsuariosViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstUsuarios(LstUsuariosViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditUsuarios(int? UsuarioId)
        {
            AddEditUsuariosViewModel objViewModel = new AddEditUsuariosViewModel();
            objViewModel.CargarDatos(UsuarioId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditUsuarios(AddEditUsuariosViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Usuarios objUsuario = new Usuarios();

            if (objViewModel.UsuarioId.HasValue)
            {
                objUsuario = context.Usuarios.FirstOrDefault(X =>
                                            X.UsuarioId == objViewModel.UsuarioId);
                objUsuario.Nombre = objViewModel.Nombre;
                objUsuario.Paterno = objViewModel.Paterno;
                objUsuario.Materno = objViewModel.Materno;
                objUsuario.Usuario = objViewModel.Usuario;
                objUsuario.Password = objViewModel.Password;
                objUsuario.EstatusId = objViewModel.EstatusId;
                objUsuario.RolId = (int)objViewModel.RolId;
            }
            else
            {
                objUsuario.Nombre = objViewModel.Nombre;
                objUsuario.Paterno = objViewModel.Paterno;
                objUsuario.Materno = objViewModel.Materno;
                objUsuario.Usuario = objViewModel.Usuario;
                objUsuario.Password = objViewModel.Password;
                objUsuario.EstatusId = objViewModel.EstatusId;
                objUsuario.RolId = (int)objViewModel.RolId;
                context.Usuarios.Add(objUsuario);
            }

            context.SaveChanges();
            return RedirectToAction("lstUsuarios");
        }

        [HttpGet]
        public ActionResult DeleteUsuarios(int? UsuarioId)
        {
            DeleteUsuariosViewModel objViewModel = new DeleteUsuariosViewModel();
            objViewModel.CargarDatos(UsuarioId);

            LBPEntities context = new LBPEntities();
            Usuarios objUsuario = new Usuarios();

            if (objViewModel.UsuariosId.HasValue)
            {
                objUsuario = context.Usuarios.FirstOrDefault(X => X.UsuarioId == objViewModel.UsuariosId);
            }
            context.Usuarios.Remove(objUsuario);
            context.SaveChanges();

            return RedirectToAction("LstUsuarios");

        }
        #endregion

        #region EQUIPOS


        [HttpGet]
        public ActionResult LstEquipos()
        {
            LstEquiposViewModel objViewModel = new LstEquiposViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstEquipos(LstEquiposViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditEquipos(int? EquipoId)
        {
            AddEditEquiposViewModel objViewModel = new AddEditEquiposViewModel();
            objViewModel.CargarDatos(EquipoId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditEquipos(AddEditEquiposViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Equipos objEquipo = new Equipos();

            if (objViewModel.EquipoId.HasValue)
            {
                objEquipo = context.Equipos.FirstOrDefault(X =>
                                            X.EquipoId == objViewModel.EquipoId);
                objEquipo.Nombre = objViewModel.Nombre;
            }
            else
            {
                objEquipo.Nombre = objViewModel.Nombre;
                context.Equipos.Add(objEquipo);
            }

            context.SaveChanges();
            return RedirectToAction("LstEquipos");
        }


        [HttpGet]
        public ActionResult DeleteEquipos(int? EquipoId)
        {
            DeleteEquiposViewModel objViewModel = new DeleteEquiposViewModel();
            objViewModel.CargarDatos(EquipoId);

            LBPEntities context = new LBPEntities();
            Equipos objEquipo = new Equipos();

            if (objViewModel.EquipoId.HasValue)
            {
                objEquipo = context.Equipos.FirstOrDefault(X => X.EquipoId == objViewModel.EquipoId);
            }
            context.Equipos.Remove(objEquipo);
            context.SaveChanges();

            return RedirectToAction("LstEquipos");
        }
        #endregion

        #region ROLES


        [HttpGet]
        public ActionResult LstRoles()
        {
            LstRolesViewModel objViewModel = new LstRolesViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstRoles(LstRolesViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditRoles(int? RolId)
        {
            AddEditRolesViewModel objViewModel = new AddEditRolesViewModel();
            objViewModel.CargarDatos(RolId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditRoles(AddEditRolesViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Roles objRol = new Roles();

            if (objViewModel.RolId.HasValue)
            {
                objRol = context.Roles.FirstOrDefault(X =>
                                            X.RolId == objViewModel.RolId);
                objRol.Acronimo = objViewModel.Acronimo;
                objRol.Descripcion = objViewModel.Descripcion;
            }
            else
            {
                objRol.Acronimo = objViewModel.Acronimo;
                objRol.Descripcion = objViewModel.Descripcion;
                context.Roles.Add(objRol);
            }

            context.SaveChanges();
            return RedirectToAction("LstRoles");
        }


        [HttpGet]
        public ActionResult DeleteRoles(int? RolId)
        {
            DeleteRolesViewModel objViewModel = new DeleteRolesViewModel();
            objViewModel.CargarDatos(RolId);

            LBPEntities context = new LBPEntities();
            Roles objRol = new Roles();

            if (objViewModel.RolId.HasValue)
            {
                objRol = context.Roles.FirstOrDefault(X => X.RolId == objViewModel.RolId);
            }
            context.Roles.Remove(objRol);
            context.SaveChanges();

            return RedirectToAction("LstRoles");
        }
        #endregion

        #region REGISTRAR


        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            RegistarViewModel objViewMolel = new RegistarViewModel();

            return View(objViewMolel);

        }


        [HttpPost]
        public ActionResult RegistrarUsuario(RegistarViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Usuarios objUsuario = new Usuarios();

            if (objUsuario == null)
            {
                return View(objViewModel);
            }

            List<Usuarios> lstUsuarios = new List<Usuarios>();
            lstUsuarios = context.Usuarios.ToList();

            for (int i = 0; i < lstUsuarios.Count; i++)
            {
                if (objViewModel.Usuario == lstUsuarios[i].Usuario)
                {
                    return View(objViewModel);
                }
                else
                {
                    if (objViewModel.Usuario == null || objViewModel.Password == null || objViewModel.Nombre == null ||
                        objViewModel.Paterno == null || objViewModel.Materno == null)
                    {
                        return View(objViewModel);
                    }
                    else
                    {
                        objUsuario.Nombre = objViewModel.Nombre;
                        objUsuario.Paterno = objViewModel.Paterno;
                        objUsuario.Materno = objViewModel.Materno;
                        objUsuario.Usuario = objViewModel.Usuario;
                        objUsuario.Password = objViewModel.Password;
                        objUsuario.EstatusId = 2;
                        objUsuario.RolId = 3;
                    }
                }
            }
            context.Usuarios.Add(objUsuario);
            context.SaveChanges();

            return RedirectToAction("Login");
        }

        #endregion

        #region SESIONES


        [HttpGet]
        public ActionResult LstSesiones()
        {
            LstSesionesViewModel objViewModel = new LstSesionesViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstSesiones(LstSesionesViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditSesiones(int? SesionId)
        {
            AddEditSesionesViewModel objViewModel = new AddEditSesionesViewModel();
            objViewModel.CargaDatos(SesionId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditSesiones(AddEditSesionesViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Sesiones objSesion = new Sesiones();

            if (objViewModel.SesionId.HasValue)
            {
                objSesion = context.Sesiones.FirstOrDefault(X =>
                                            X.SesionId == objViewModel.SesionId);
                objSesion.InicioSesion = objViewModel.IniciSesion;
                objSesion.CierreSesion = objViewModel.CierreSesion;
                objSesion.UsuarioId = objViewModel.UsuarioId;
                objSesion.RolId = (int)objViewModel.RolId;
            }
            else
            {
                objSesion.InicioSesion = objViewModel.IniciSesion;
                objSesion.CierreSesion = objViewModel.CierreSesion;
                objSesion.UsuarioId = objViewModel.UsuarioId;
                objSesion.RolId = (int)objViewModel.RolId;
                context.Sesiones.Add(objSesion);
            }

            context.SaveChanges();
            return RedirectToAction("LstSesiones");
        }

        public ActionResult DeleteSesion(int? SesionId)
        {
            DeleteSesionViewModel objViewModel = new DeleteSesionViewModel();
            objViewModel.CargarDatos(SesionId);

            LBPEntities context = new LBPEntities();
            Sesiones objSesion = new Sesiones();

            if (objViewModel.SesionId.HasValue)
            {
                objSesion = context.Sesiones.FirstOrDefault(X => X.SesionId == objViewModel.SesionId);
            }
            context.Sesiones.Remove(objSesion);
            context.SaveChanges();

            return RedirectToAction("LstSesiones");
        }
        #endregion

        #region JUGADORES


        [HttpGet]
        public ActionResult LstJugadores()
        {
            LstJugadoresViewModel objViewModel = new LstJugadoresViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstJugadores(LstJugadoresViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditJugadores(int? JugadorId)
        {
            AddEditJugadoresViewModel objViewModel = new AddEditJugadoresViewModel();
            objViewModel.CargarDatos(JugadorId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditJugadores(AddEditJugadoresViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Jugadores objJugador = new Jugadores();

            if (objViewModel.JugadorId.HasValue)
            {
                objJugador = context.Jugadores.FirstOrDefault(X =>
                                            X.JugadorId == objViewModel.JugadorId);
                objJugador.Nombre = objViewModel.Nombre;
                objJugador.Paterno = objViewModel.Paterno;
                objJugador.Materno = objViewModel.Materno;
                objJugador.Numero = (int)objViewModel.Numero;
                objJugador.EquipoId = (int)objViewModel.EquipoId;
            }
            else
            {
                objJugador.Nombre = objViewModel.Nombre;
                objJugador.Paterno = objViewModel.Paterno;
                objJugador.Materno = objViewModel.Materno;
                objJugador.Numero = (int)objViewModel.Numero;
                objJugador.EquipoId = (int)objViewModel.EquipoId;
                context.Jugadores.Add(objJugador);
            }

            context.SaveChanges();
            return RedirectToAction("LstJugadores");
        }

        [HttpGet]
        public ActionResult DeleteJugadores(int? JugadorId)
        {
            DeleteJugadoresViewModel objViewModel = new DeleteJugadoresViewModel();
            objViewModel.CargarDatos(JugadorId);

            LBPEntities context = new LBPEntities();
            Jugadores objJugador = new Jugadores();

            if (objViewModel.JugadorId.HasValue)
            {
                objJugador = context.Jugadores.FirstOrDefault(X => X.JugadorId == objViewModel.JugadorId);
            }
            context.Jugadores.Remove(objJugador);
            context.SaveChanges();

            return RedirectToAction("LstJugadores");
        }
        #endregion

        #region PARTIDOS


        [HttpGet]
        public ActionResult LstPartidos()
        {
            LstPartidosViewModel objViewModel = new LstPartidosViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstPartidos(LstPartidosViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditPartidos(int? PartidoId)
        {
            AddEditPartidosViewModel objViewModel = new AddEditPartidosViewModel();
            objViewModel.CargarDatos(PartidoId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditPartidos(AddEditPartidosViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Partidos objPartido = new Partidos();

            if (objViewModel.PartidoId.HasValue)
            {
                objPartido = context.Partidos.FirstOrDefault(X =>
                                            X.PartidoId == objViewModel.PartidoId);
                objPartido.Horario = objViewModel.Horario;
                objPartido.TemporadaId = objViewModel.TemporadaId;
                objPartido.JornadaId = objViewModel.JornadaId;
                objPartido.Fecha = objViewModel.Fecha;
                objPartido.EquipoLocalId = objViewModel.EquipoLocalId;
                objPartido.PuntosLocal = objViewModel.PuntosLocal;
                objPartido.EquipoVisitanteId = objViewModel.EquipoVisitante;
                objPartido.PuntosVisitante = objViewModel.PuntosVisitante;
            }
            else
            {
                objPartido.Horario = objViewModel.Horario;
                objPartido.TemporadaId = objViewModel.TemporadaId;
                objPartido.JornadaId = objViewModel.JornadaId;
                objPartido.Fecha = objViewModel.Fecha;
                objPartido.EquipoLocalId = objViewModel.EquipoLocalId;
                objPartido.PuntosLocal = objViewModel.PuntosLocal;
                objPartido.EquipoVisitanteId = objViewModel.EquipoVisitante;
                objPartido.PuntosVisitante = objViewModel.PuntosVisitante;
                context.Partidos.Add(objPartido);
            }
            context.SaveChanges();
            return RedirectToAction("LstPartidos");
        }

        [HttpGet]
        public ActionResult DeletePartidos(int? PartidoId)
        {
            DeletePartidosViewModel objViewModel = new DeletePartidosViewModel();
            objViewModel.CargarDatos(PartidoId);

            LBPEntities context = new LBPEntities();
            Partidos objPartido = new Partidos();

            if (objViewModel.PartidoId.HasValue)
            {
                objPartido = context.Partidos.FirstOrDefault(X => X.PartidoId == objViewModel.PartidoId);
            }
            context.Partidos.Remove(objPartido);
            context.SaveChanges();

            return RedirectToAction("LstPartidos");
        }
        #endregion

        #region TEMPORADAS

        [HttpGet]
        public ActionResult LstTemporadas()
        {
            LstTemporadasViewModel objViewModel = new LstTemporadasViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult LstTemporadas(LstTemporadasViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);

            return View(objViewModel);
        }


        [HttpGet]
        public ActionResult AddEditTemporadas(int? TemporadaId)
        {
            AddEditTemporadasViewModel objViewModel = new AddEditTemporadasViewModel();
            objViewModel.CargarDatos(TemporadaId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditTemporadas(AddEditTemporadasViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Temporada objTemporada = new Temporada();

            if (objViewModel.TemporadaId.HasValue)
            {
                objTemporada = context.Temporada.FirstOrDefault(X => X.TemporadaId == objViewModel.TemporadaId);

                objTemporada.Descripcion = objViewModel.Descripcion;
            }
            else
            {
                objTemporada.Descripcion = objViewModel.Descripcion;
                context.Temporada.Add(objTemporada);
            }
            context.SaveChanges();

            return RedirectToAction("LstTemporadas");
        }

        [HttpGet]
        public ActionResult DeleteTemporadas(DeleteTemporadasViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Temporada objTemporada = new Temporada();

            if (objViewModel.TemporadaId.HasValue)
            {
                objTemporada = context.Temporada.FirstOrDefault(X => X.TemporadaId == objViewModel.TemporadaId);
            }
            context.Temporada.Remove(objTemporada);
            context.SaveChanges();

            return RedirectToAction("LstTemporadas");
        }

        #endregion

        #region JORNADAS


        [HttpGet]
        public ActionResult LstJornadas()
        {
            LstJornadasViewModel objViewModel = new LstJornadasViewModel();
            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult LstJornadas(LstJornadasViewModel objViewModel)
        {
            objViewModel.CargaDatos(objViewModel.Filtro);
            return View(objViewModel);
        }

        [HttpGet]
        public ActionResult AddEditJornadas(int? JornadaId)
        {
            AddEditJornadasViewModel objViewModel = new AddEditJornadasViewModel();
            objViewModel.CargarDatos(JornadaId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditJornadas(AddEditJornadasViewModel objViewModel)
        {
            LBPEntities context = new LBPEntities();
            Jornadas objJornada = new Jornadas();

            if (objViewModel.JornadaId.HasValue)
            {
                objJornada = context.Jornadas.FirstOrDefault(X => X.JornadaId == objViewModel.JornadaId);
                objJornada.Descripcion = objViewModel.Descripcion;
            }
            else
            {
                objJornada.Descripcion = objViewModel.Descripcion;
                context.Jornadas.Add(objJornada);
            }
            context.SaveChanges();
            return RedirectToAction("LstJornadas");
        }


        [HttpGet]
        public ActionResult DeleteJornadas(int? JornadaId)
        {
            DeleteJornadasViewModel objViewModel = new DeleteJornadasViewModel();
            objViewModel.CargarDatos(JornadaId);

            LBPEntities context = new LBPEntities();
            Jornadas objJornadas = new Jornadas();

            if (objViewModel.JornadaId.HasValue)
            {
                objJornadas = context.Jornadas.FirstOrDefault(X => X.JornadaId == JornadaId);
            }
            context.Jornadas.Remove(objJornadas);
            context.SaveChanges();

            return RedirectToAction("LstJornadas");
        }

        #endregion

    }
}
