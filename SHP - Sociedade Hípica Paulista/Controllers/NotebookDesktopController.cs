using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Models;
using SHP___Sociedade_Hípica_Paulista.Services.NotebookDesktopService;
using SHP___Sociedade_Hípica_Paulista.Services.SessaoService;
using System.Data;
using System.Threading.Tasks;


namespace SHP___Sociedade_Hípica_Paulista.Controllers
{
    public class NotebookDesktopController : Controller
    {

        readonly private ISessaoInterface _sessaoInterface;
        readonly private INotebookDesktopInterface _notebookDesktopInterface;

        public NotebookDesktopController(INotebookDesktopInterface notebookDesktopInterface ,ISessaoInterface sessaoInterface)
        {
            _sessaoInterface = sessaoInterface;
            _notebookDesktopInterface = notebookDesktopInterface;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var notebooksDesktops = await _notebookDesktopInterface.BuscarNotebookDesktop();

            return View(notebooksDesktops.Dados);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var notebooksDesktop = await _notebookDesktopInterface.BuscarNotebookDesktopPorId(id);

            return View(notebooksDesktop.Dados);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var notebooksDesktop = await _notebookDesktopInterface.BuscarNotebookDesktopPorId(id);

            return View(notebooksDesktop.Dados);
        }

        public async Task<IActionResult> Exportar()
        {

            var dados = await _notebookDesktopInterface.BuscarDadosNotebookDesktopExcel();

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


        [HttpPost]
        public async Task<IActionResult> Cadastrar(Notebook_DesktopModel Notebook_Desktop)
        {
            if (ModelState.IsValid)
            {

                var notebookDesktopResult = await _notebookDesktopInterface.CadastrarNotebookDesktop(Notebook_Desktop);

                if (notebookDesktopResult.Status)
                {
                    TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                    return View(Notebook_Desktop);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Notebook_DesktopModel Notebook_Desktop)
        {
            if (ModelState.IsValid)
            {
                var notebookDesktopResult = await _notebookDesktopInterface.EditarNotebookDesktop(Notebook_Desktop);

                if(notebookDesktopResult.Status)
                {
                    TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                    return View(notebookDesktopResult);
                }

                return RedirectToAction("Index");
            }
            return View(Notebook_Desktop);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Notebook_DesktopModel Notebook_Desktop)
        {
            if (Notebook_Desktop == null)
            {
                TempData["MensagemErro"] = "Notebook ou Desktop não localizado!";
                return RedirectToAction("Index");
            }

            var notebookDesktopResult = await _notebookDesktopInterface.RemoveNotebookDesktop(Notebook_Desktop);

            if(notebookDesktopResult.Status)
            {
                TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;    
            }
            else
            {
                TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                return View(Notebook_Desktop);
            }

            return RedirectToAction("Index");

        }
    }
}
