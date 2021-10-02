using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErrorLog.Models
{
    public class Error
    {
		public int Id { get; set; }

		/// <summary>
		/// Код ошибки
		/// <summary>
		[Required]
		public string ErrorCode { get; set; }

		/// <summary>
		/// Тип ошибки
		/// <summary>
		[Required]
		public string Type { get; set; }

		/// <summary>
		/// Дата и время
		/// <summary>
		[Required]
		public DateTime Date { get; set; }

		/// <summary>
		/// Описание ошибки
		/// <summary>
		[Required]
		public string Description { get; set; }

		/// <summary>
		/// Решение ошибки
		/// <summary>
		public string Solution { get; set; }
	}
}