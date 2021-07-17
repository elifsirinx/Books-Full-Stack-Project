using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenre();
        IList<GenreListResponse> GetGenreByGenreName(string genreName);
        IList<GenreListResponse> GetGenreByBookTitle(string BookTitle);
        GenreListResponse GetGenreById(int id);
        int AddGenre(AddNewGenreRequest request);
        int UpdateGenre(EditGenreRequest request);
        void DeleteGenre(int id);
    }
}
