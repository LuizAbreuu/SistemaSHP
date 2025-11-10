using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Models;
using System.Data;

namespace SHP___Sociedade_Hípica_Paulista.Controllers
{
    public class NotebookDesktopController : Controller
    {

        readonly private ApplicationDbContext _db;

        public NotebookDesktopController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Notebook_DesktopModel> Notebook_Desktops = _db.Notebook_Desktops;
            return View(Notebook_Desktops);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Notebook_DesktopModel Notebook_Desktop = _db.Notebook_Desktops.FirstOrDefault(x => x.Id == id);

            if (Notebook_Desktop == null)
            {
                return NotFound();
            }

            return View(Notebook_Desktop);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Notebook_DesktopModel Notebook_Desktop = _db.Notebook_Desktops.FirstOrDefault(x => x.Id == id);

            if (Notebook_Desktop == null)
            {
                return NotFound();
            }

            return View(Notebook_Desktop);
        }

        public IActionResult Exportar()
        {

            var dados = GetDados();

            using(XLWorkbook workBook = new XLWorkbook())
            {
                workBook.AddWorksheet(dados, "Notebook´s e Desktop´s");

                using (MemoryStream ms = new MemoryStream()) 
                {
                    workBook.SaveAs(ms);
                    return File(ms.ToArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Notebook´s e Desktop´s.xlsx");
                }
            }
        }

        private DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Notebook´s e Desktop´s";

            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Tipo", typeof(string));
            dataTable.Columns.Add("Responsável instalação", typeof(string));
            dataTable.Columns.Add("Usuário", typeof(string));
            dataTable.Columns.Add("Departamento", typeof(string));
            dataTable.Columns.Add("Procedencia", typeof(string));
            dataTable.Columns.Add("Marca", typeof(string));
            dataTable.Columns.Add("Modelo", typeof(string));
            dataTable.Columns.Add("Processador", typeof(string));
            dataTable.Columns.Add("Memoria", typeof(int));
            dataTable.Columns.Add("Espaço/Tipo disco", typeof(string));
            dataTable.Columns.Add("Sistema Operacional", typeof(string));
            dataTable.Columns.Add("Número de Série", typeof(string));
            dataTable.Columns.Add("Data Instalação", typeof(DateTime));
            dataTable.Columns.Add("Data Inventário", typeof(DateTime));
            dataTable.Columns.Add("Log Equipamento", typeof(string));

            var dados = _db.Notebook_Desktops.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(Notebook_Desktop =>
                {
                    dataTable.Rows.Add(Notebook_Desktop.Nome, Notebook_Desktop.Tipo, Notebook_Desktop.ResponsavelInstalacao, Notebook_Desktop.Usuario,
                        Notebook_Desktop.Departamento, Notebook_Desktop.Procedencia, Notebook_Desktop.Marca, Notebook_Desktop.Modelo, Notebook_Desktop.Processador,
                        Notebook_Desktop.Memoria, Notebook_Desktop.Espaco_TipoDisco, Notebook_Desktop.SistemaOperacional, Notebook_Desktop.NumeroSerie, Notebook_Desktop.DataInstalacao,
                        Notebook_Desktop.DataInventario, Notebook_Desktop.LogEquipamento);
                });
            }

            return dataTable;
        }


        [HttpPost]
        public IActionResult Cadastrar(Notebook_DesktopModel Notebook_Desktop)
        {
            if (ModelState.IsValid)
            {
                _db.Notebook_Desktops.Add(Notebook_Desktop);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Notebook/Desktop cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(Notebook_DesktopModel Notebook_Desktop)
        {
            if (ModelState.IsValid)
            {
                _db.Notebook_Desktops.Update(Notebook_Desktop);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Notebook/Desktop editado com sucesso!";

                return RedirectToAction("Index");
            }
            return View(Notebook_Desktop);
        }

        [HttpPost]
        public IActionResult Excluir(Notebook_DesktopModel Notebook_Desktop)
        {
            if (Notebook_Desktop == null)
            {
                return NotFound();
            }

            _db.Notebook_Desktops.Remove(Notebook_Desktop);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Notebook/Desktop excluído com sucesso!";

            return RedirectToAction("Index");

        }
    }
}
