﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyCommerce.Extensions;

namespace SkyCommerce.Site.Controllers
{
	[Route("conta")]
	public class AccountController : Controller
	{
		[HttpGet]
		[Authorize]
		[Route("entrar")]
		public IActionResult Login(string returnUrl = null)
		{
			if (returnUrl.IsPresent())
				return Redirect(returnUrl);

			return RedirectToAction("Index", "Home");
		}

		[Authorize, Route("minha-conta")]
		public IActionResult MinhaConta()
		{
			return View();
		}

		[Route("sair")]
		public IActionResult Sair()
		{
			return SignOut("Cookies", "oidc");
		}
	}
}
