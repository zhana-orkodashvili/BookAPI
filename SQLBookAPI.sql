create database LibraryDB
use LibraryDB

CREATE TABLE books (
   book_id VARCHAR(20),
   title VARCHAR(50) not null check (len(title)>0),
   author VARCHAR(50) not null check (len(author)>0),
   publication_date date check (len(publication_date)>0),

   CONSTRAINT books_pk PRIMARY KEY (book_id),
   CONSTRAINT book_id_len CHECK(len(book_id)=5),
   CONSTRAINT date_in_past CHECK (publication_date<getdate())
   
   )

select * from books
