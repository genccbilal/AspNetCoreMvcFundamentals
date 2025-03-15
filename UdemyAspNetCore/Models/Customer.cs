using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Models
{
	public class Customer
	{
		[Required(ErrorMessage ="Id alanı gereklidir")]
		[Range(1,int.MaxValue)]
		public int Id{ get; set; }
		[Required(ErrorMessage ="Ad Alanı Boş Bırakılamaz")]
		[MaxLength(30,ErrorMessage ="En fazla 30 karakter olabilir")]
		public string FirstName { get; set; }
		[Required(ErrorMessage ="Soyad Alanı Boş Bırakılamaz")]
		[MinLength(3, ErrorMessage = "soyad alanı en az 3 karakterli olmalı")]
		public string LastName { get; set; }
		[Range(18, 40, ErrorMessage = "Yaş değeri en az 18 , en fazla 40 olabilir")]
		public int Age { get; set; }

	}
}
