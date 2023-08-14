using Final_DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Final_DB.Controllers
{
    public class control_user : Controller
    {
        public IActionResult Index()
        {
            //con es la conexion
            using (SqlConnection con = new(Configuration["ConnectionStrings:conexion"]))
            {
                using SqlCommand cmd = new("db_vista", con);
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd);
                    DataTable dt = new ();
                    da.Fill(dt);
                    da.Dispose();
                    List<Model_User> lista = new ();

                    for (int i = 0; i < dt.Rows.Count ; i++)
                    {
                        lista.Add(new Model_User()
                        {
                            ID_Paciente = Convert.ToInt32(dt.Rows[i][0]),
                            Nombre = (dt.Rows[i][1]).ToString(),
                            Apellidos = (dt.Rows[i][2]).ToString(),
                            Telefono = (dt.Rows[i][3]).ToString(),
                            Sexo = (dt.Rows[i][4]).ToString (),
                            Domicilio = (dt.Rows[i][5]).ToString(),
                            Edad = Convert.ToInt32(dt.Rows[i][6]),
                            Correo_Electronico = (dt.Rows[i][7]).ToString(),
                            ID_Seguro = Convert.ToInt32(dt.Rows[i][8]),
                            ID_AreaMedica = Convert.ToInt32(dt.Rows[i][9])
                        });

                    }
                    ViewBag.usuario = lista;
                    con.Close();
                }
                return View();

            }   
        
        }

        public IConfiguration Configuration { get; }
       

        public control_user(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Model_User usuarios)
        {
            using (SqlConnection con = new(Configuration["ConnectionStrings:conexion"]))
            {
                using SqlCommand cmd = new("db_registro", con);
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = usuarios.Nombre;
                    cmd.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = usuarios.Apellidos;
                    cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = usuarios.Telefono;
                    cmd.Parameters.Add("@Sexo", System.Data.SqlDbType.VarChar).Value = usuarios.Sexo;
                    cmd.Parameters.Add("@Domicilio", System.Data.SqlDbType.VarChar).Value = usuarios.Domicilio;
                    cmd.Parameters.Add("@Edad", System.Data.SqlDbType.Int).Value = usuarios.Edad;
                    cmd.Parameters.Add("@Correo_Electronico", System.Data.SqlDbType.VarChar).Value = usuarios.Correo_Electronico;
                    cmd.Parameters.Add("@ID_Seguro", System.Data.SqlDbType.Int).Value = usuarios.ID_Seguro;
                    cmd.Parameters.Add("@ID_AreaMedica", System.Data.SqlDbType.VarChar).Value = usuarios.ID_AreaMedica;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return Redirect("Index");
            }

        }

    }
}

