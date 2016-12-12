using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Issue : AppCode.BaseEntity
    {

        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        public int? BoardID { get; set; }
        [ForeignKey("BoardID")]
        public Board Board { get; set; }

        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        public int? CollobratorID { get; set; }
        [ForeignKey("CollobratorID")]
        public Collobrator Collobrator { get; set; }

        public int? ColumnID { get; set; }
        [ForeignKey("ColumnID")]
        public Column Column { get; set; }

        public int? PriorityID { get; set; }
        [ForeignKey("PriorityID")]
        public Priority Priority { get; set; }

        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public Type Type { get; set; }



        public virtual List<Watcher> Watchers { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<IssueTag> IssueTags { get; set; }


        public string GetDescriptionPart(int Length = 150)
        {

            if (this.Description != null && this.Description.Length >= Length)
            {
                return this.Description.Substring(0, Length);
            }
            else if (this.Description != null && this.Description.Length < Length)
            {
                return this.Description;
            }
            else
            {
                return "";
            }
        }

        public HtmlString RenderTags(string Seperator = ", ")
        {

            string ReturnHTML = "";

            if (this.IssueTags != null && this.IssueTags.Count > 0)
            {

                foreach (var item in this.IssueTags)
                {
                    if (ReturnHTML == "")
                    {
                        ReturnHTML = "<span class='badge'>" + item.Tag.Name + "</span>";
                    }
                    else
                    {
                        ReturnHTML = ReturnHTML + Seperator + "<span class='badge'>" + item.Tag+ "</span>";
                    }


                }
            }
            HtmlString oHtmlString = new HtmlString(ReturnHTML);

            return oHtmlString;
        }

    }
}