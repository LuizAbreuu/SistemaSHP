using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SHP___Sociedade_Hípica_Paulista.Data;
using SHP___Sociedade_Hípica_Paulista.Models;
using SHP___Sociedade_Hípica_Paulista.Services.NotebookDesktopService;
using Microsoft.AspNetCore.Authorization;
using SHP___Sociedade_Hípica_Paulista.Models.ViewModels;
using System.Data;
using System.Threading.Tasks;


namespace SHP___Sociedade_Hípica_Paulista.Controllers
{
    [Authorize]
    public class NotebookDesktopController : Controller
    {

        private readonly INotebookDesktopInterface _notebookDesktopInterface;

        public NotebookDesktopController(INotebookDesktopInterface notebookDesktopInterface)
        {
            _notebookDesktopInterface = notebookDesktopInterface;
        }

        public async Task<IActionResult> Index()
        {


            var notebooksDesktops = await _notebookDesktopInterface.BuscarNotebookDesktop();
            var viewModels = notebooksDesktops.Dados?.Select(NotebookDesktopViewModel.FromModel).ToList() ?? new List<NotebookDesktopViewModel>();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {


            var notebooksDesktop = await _notebookDesktopInterface.BuscarNotebookDesktopPorId(id);

            return View(NotebookDesktopViewModel.FromModel(notebooksDesktop.Dados));
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {


            var notebooksDesktop = await _notebookDesktopInterface.BuscarNotebookDesktopPorId(id);

            return View(NotebookDesktopViewModel.FromModel(notebooksDesktop.Dados));
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
        public async Task<IActionResult> Cadastrar(NotebookDesktopViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var Notebook_Desktop = NotebookDesktopViewModel.ToModel(viewModel);
                var notebookDesktopResult = await _notebookDesktopInterface.CadastrarNotebookDesktop(Notebook_Desktop);

                if (notebookDesktopResult.Status)
                {
                    TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                    return View(viewModel);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(NotebookDesktopViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var Notebook_Desktop = NotebookDesktopViewModel.ToModel(viewModel);
                var notebookDesktopResult = await _notebookDesktopInterface.EditarNotebookDesktop(Notebook_Desktop);

                if(notebookDesktopResult.Status)
                {
                    TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                    return View(viewModel);
                }

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(NotebookDesktopViewModel viewModel)
        {
            if (viewModel == null)
            {
                TempData["MensagemErro"] = "Notebook ou Desktop não localizado!";
                return RedirectToAction("Index");
            }

            var Notebook_Desktop = NotebookDesktopViewModel.ToModel(viewModel);
            var notebookDesktopResult = await _notebookDesktopInterface.RemoveNotebookDesktop(Notebook_Desktop);

            if(notebookDesktopResult.Status)
            {
                TempData["MensagemSucesso"] = notebookDesktopResult.Mensagem;    
            }
            else
            {
                TempData["MensagemErro"] = notebookDesktopResult.Mensagem;
                return View(viewModel);
            }

            return RedirectToAction("Index");

        }
    }
}
