using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thirsty.Repositories;

namespace Thirsty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuRepository<Style> styleMenuRepository;
        private readonly IMenuRepository<Available> beerAvailibilityMenuRepository;
        private readonly IMenuRepository<Glass> glassMenuRepository;
        private readonly BeerRepository beerRepository;

        public HomeController() :
            this(new StyleMenuRepository(),
                new AvailibilityMenuRespository(),
                new GlasswareMenuRespository(),
                new BeerRepository())
        {
        }

        public HomeController(IMenuRepository<Style> styleMenuRepository, 
            IMenuRepository<Available> beerAvailibilityMenuRepository,
            IMenuRepository<Glass> glassMenuRepository,
            BeerRepository beerRepository)
        {
            this.styleMenuRepository = styleMenuRepository;
            this.beerAvailibilityMenuRepository = beerAvailibilityMenuRepository;
            this.glassMenuRepository = glassMenuRepository;
            this.beerRepository = beerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index(FilterParameters parameters)
        {
            var viewModel = new HomePageViewModel
            {
                Page = 1,
                Availabilities = await beerAvailibilityMenuRepository.GetMenu(),
                Glasswares = await glassMenuRepository.GetMenu(),
                Styles = await styleMenuRepository.GetMenu(),
                Beers = await beerRepository.GetBeers(parameters.GetQueryConstraints()),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HomePageViewModel model)
        {
            model.Beers = await beerRepository.GetBeers(model.GetQueryConstraints());
            model.Glasswares = await glassMenuRepository.GetMenu();
            model.Availabilities = await beerAvailibilityMenuRepository.GetMenu();
            model.Styles = await styleMenuRepository.GetMenu();
            return View(model);
        }
    }
}