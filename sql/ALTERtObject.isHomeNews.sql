ALTER TABLE tObject ADD isHomeNews bit default 0;

GO

Update tObject set isHomeNews = 0;