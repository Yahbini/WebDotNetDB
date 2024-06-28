using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDotNetDB.Models;

public class CategoryMetaData
{
    [Required]
    public string Name { get; set; }

    [ModelMetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }

}
