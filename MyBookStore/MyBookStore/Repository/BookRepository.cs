﻿using Microsoft.EntityFrameworkCore;
using MyBookStore.Data;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookpdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        CoverImageUrl = book.CoverImageUrl
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookpdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }
    }
}
