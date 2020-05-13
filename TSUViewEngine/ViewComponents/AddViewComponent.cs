using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSUViewEngine.Models;

namespace TSUViewEngine.ViewComponents
{
    public class AddViewComponent
    {
        private IAddRepository _repository;

        public AddViewComponent(IAddRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            AddModel add = _repository.Adds.FirstOrDefault();
            return new HtmlContentViewComponentResult(new HtmlString($"<iframe src='{add.Url}' frameborder='0' scrolling='no' width='100%' height='100%'></iframe>"));
        }
    }
}
