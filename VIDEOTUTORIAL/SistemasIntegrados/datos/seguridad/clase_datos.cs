using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clases.seguridad;
using System.IO;
namespace datos.seguridad
{
    public class clase_datos
    {

        public List<clase_persona> consulta() {
            try
            {
                List<clase_persona> lista = new List<clase_persona>();
                SeguridadEntities ent = new SeguridadEntities();
                var con = from w in ent.persona select w;
                //el foreach recorre cada registro que me trajo de la consulta en la variable con
                foreach (var item in con)
                {
                    clase_persona clas = new clase_persona();
                    clas.codigo = item.codigo;
                    clas.nombre = item.nombre;
                    clas.apellido = item.apellido;
                    //las variables pueden ser nulas y no son soportadas
                    //vamos a hacer un cast o convertir
                    //para fechanacimiento haremos un convert y para genero un cast de int para diferenciar
                    //
                    clas.fechaNacimiento = (DateTime)(item.fechaNacimiento);
                    clas.genero = Convert.ToInt32(item.genero);
                    
                    clas.telefono = item.telefono;
                    //agregamos el registro a la lista
                    lista.Add(clas);
                }

                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<clase_genero> consultaGenero()
        {
            try
            {
                List<clase_genero> lista = new List<clase_genero>();
                SeguridadEntities ent = new SeguridadEntities();
                var con = from w in ent.genero select w;
                //el foreach recorre cada registro que me trajo de la consulta en la variable con
                foreach (var item in con)
                {
                    clase_genero clas = new clase_genero();
                    clas.codigo = item.codigo;
                    clas.nombre = item.nombre;
                    
                    lista.Add(clas);
                }
                //listo casi todo es muy parecido
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void modificar(clase_persona perso) {
            using (SeguridadEntities ent =new SeguridadEntities())
            {
                var x =(from q in ent.persona where q.codigo==perso.codigo select q).First();
                x.nombre = perso.nombre;
                x.apellido = perso.apellido;
                x.fechaNacimiento = perso.fechaNacimiento;
                x.genero = perso.genero;
                x.telefono = perso.telefono;
                ent.SaveChanges();
            }
        }
        public Boolean guardar(clase_persona perso)
        {
            try
            {
                using (SeguridadEntities ent = new SeguridadEntities())
                {
                    persona per = new persona()
                    {
                        codigo = perso.codigo,
                        nombre = perso.nombre,
                        apellido = perso.apellido,
                        fechaNacimiento = perso.fechaNacimiento,
                        genero = perso.genero,
                        telefono = perso.telefono
                    };
                    ent.AddTopersona(per);
                    ent.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public void eliminar(clase_persona perso)
        {
            using (SeguridadEntities ent = new SeguridadEntities())
            {
                //hago un where por el primarykey codigo
                var x = (from q in ent.persona where q.codigo == perso.codigo select q).First();
                //eliminar es muy parecido
                //elimina el registro que me trajo el select
                ent.DeleteObject(x);
                ent.SaveChanges();


            }

        }

        public Boolean guardarLista(List<clase_persona> persoLista)
        {
            try
            {
                foreach (var perso in persoLista)
                {
                    using (SeguridadEntities ent = new SeguridadEntities())
                    {
                        persona per = new persona()
                        {
                            codigo = perso.codigo,
                            nombre = perso.nombre,
                            apellido = perso.apellido,
                            fechaNacimiento = perso.fechaNacimiento,
                            genero = perso.genero,
                            telefono = perso.telefono
                        };
                        ent.AddTopersona(per);
                        ent.SaveChanges();
                    }
                }
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<clase_info> select() { 
            List<clase_info> lista=new List<clase_info>();
            pubsEntities pubs=new pubsEntities();
            var sel = from q in pubs.pub_info select q;
            foreach (var item in sel)
            {
              clase_info clas=new clase_info();
              clas.pub_id = item.pub_id;
              clas.logo = item.logo;
              MemoryStream m = new MemoryStream(item.logo);
              clas.Imagen = m;
              //clas.Imagen2 = Image.FromStream(m);
              clas.pr_info = item.pr_info;
              lista.Add(clas);
            }

            return lista;
        }
        public Boolean guardarImagen(clase_info Info)
        {
            try
            {
                using (pubsEntities ent = new pubsEntities())
                {
                    pub_info per = new pub_info()
                    {
                        pub_id = Info.pub_id,
                        logo = Info.logo,
                        pr_info = Info.pr_info,
                    };
                    ent.AddTopub_info(per);
                    ent.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
