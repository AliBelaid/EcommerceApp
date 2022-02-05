using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Dtos;
using Microsoft.AspNetCore.Http;

namespace API.Extensions {
    public static class HttpExtensions {
        public static void AddPaginationHeader (this HttpResponse response, int itemPerPage, int currentPage, int totalItems, int totalPages) {
            var paginationHeader = new PaginationHeader (itemPerPage, currentPage, totalItems, totalPages);
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            response.Headers.Add ("Pagination", JsonSerializer.Serialize (paginationHeader,options));
             response.Headers.Add ("Access-Control-Expose-Headers", "Pagination");
          
        }
    }
}