using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SoundCore.Application.Contracts.Infrastructure;
using SoundCore.Application.Models.Searchs;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Infrastructure.Searcher
{
    public class SearchService : ISearchService
    {

        private bool _firstLoad = true;


        private readonly Directory _directory;
        private readonly Analyzer _analyzer;
        private readonly IndexWriterConfig _indexWriterConfig;


        public SearchService()
        {
            if (_firstLoad)
            {
                _firstLoad = false;
                _analyzer = new StandardAnalyzer(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT);

                // Store the index in memory:
                _directory = new RAMDirectory();
                // To store an index on disk, use this instead:
                //Directory directory = FSDirectory.open("/tmp/testindex");
                _indexWriterConfig = new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, _analyzer);
             //   TestingWriter();



            }

        }


        public async Task AddDocument<T>(T myObject)
        {
            using var iwriter = new IndexWriter(_directory, _indexWriterConfig);

            var doc = new Document();
            foreach (var property in myObject.GetType().GetProperties())
            {                       
                var field = new Field(property.Name, GetPropValue(property,property.Name).ToString(), TextField.TYPE_STORED);

                var ireader = DirectoryReader.Open(_directory);
                var isearcher = new IndexSearcher(ireader);
                var results = isearcher.Search(new TermQuery(new Term(property.Name, GetPropValue(property, property.Name).ToString())), 1);
                if(results.TotalHits == 0){
                    doc.Add(field);
                }
           
            }
     

            iwriter.AddDocument(doc);
        }

        public async Task AddDocumentList<T>(List<T> myObject)
        {
            using var iwriter = new IndexWriter(_directory, new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, _analyzer));
            iwriter.Commit();

            foreach (var item in myObject)
            {
                var doc = new Document();
              
                
                foreach (var property in item.GetType().GetProperties())
                {
                    var valueproperty = GetPropValue(property, property.Name).ToString();
                    var field = new Field(property.Name, valueproperty, TextField.TYPE_STORED);

                    var ireader = DirectoryReader.Open(_directory);
                    var isearcher = new IndexSearcher(ireader);
                    var results = isearcher.Search(new TermQuery(new Term(property.Name, GetPropValue(property, property.Name).ToString())), 1);
                    if (results.TotalHits == 0)
                    {
                        doc.Add(field);
                    }
                 
                }
                iwriter.AddDocument(doc);
            }
          
        }


        public async Task AddDocumentRoomList(List<Room> myObject)
        {
           
            using var iwriter = new IndexWriter(_directory, new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, _analyzer));
            iwriter.Commit();
            var ireader = DirectoryReader.Open(_directory);
            var isearcher = new IndexSearcher(ireader);
            foreach (var item in myObject)
            {
                var doc = new Document();

                var field1 = new Field(nameof(item.Id), item.Id.ToString(), TextField.TYPE_STORED);
                var field2 = new Field(nameof(item.SearchableField), item.SearchableField, TextField.TYPE_STORED);
                var field3 = new Field(nameof(Type), item.GetType().Name.ToString(), TextField.TYPE_STORED);
                doc.Add(field1);
                doc.Add(field2);
                doc.Add(field3);

                var parser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, "Id", _analyzer);
                var query = parser.Parse(item.Id.ToString());
                var hits = isearcher.Search(query, 1);
                if (hits.TotalHits == 0)
                {
                    iwriter.AddDocument(doc);
                }
            
            }
            ireader.Dispose();
            iwriter.Dispose();

        }


        public async Task AddDocumentAppointmentList(List<Appointment> myObject)
        {

            using var iwriter = new IndexWriter(_directory, new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, _analyzer));
            iwriter.Commit();
            var ireader = DirectoryReader.Open(_directory);
            var isearcher = new IndexSearcher(ireader);
            foreach (var item in myObject)
            {
                var doc = new Document();

                var field1 = new Field(nameof(item.Id), item.Id.ToString(), TextField.TYPE_STORED);
                var field2 = new Field(nameof(item.SearchableField), item.SearchableField, TextField.TYPE_STORED);
                var field3 = new Field(nameof(Type), item.GetType().Name.ToString(), TextField.TYPE_STORED);
                doc.Add(field1);
                doc.Add(field2);
                doc.Add(field3);

                var parser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, "Id", _analyzer);
                var query = parser.Parse(item.Id.ToString());
                var hits = isearcher.Search(query, 1);
                if (hits.TotalHits == 0)
                {
                    iwriter.AddDocument(doc);
                }

            }
            ireader.Dispose();
            iwriter.Dispose();

        }


        private static object GetPropValue(object src, string propName)
        {
            var result = src.GetType().GetProperty(propName)?.GetValue(src, null);
            if (result != null)
            {
                return result;
            }
            else
            {
                result = src.GetType().GetField(propName)?.GetValue(src);
                return result;
            }
          //  return new object();
        }

        private void TestingWriter()
        {
            try
            {
                using var iwriter = new IndexWriter(_directory, _indexWriterConfig);

                var doc = new Document();
                var text = "This is the text to be indexed.";
                doc.Add(new Field("fieldname", text, TextField.TYPE_STORED));
                doc.Add(new Field("fieldname", "prova", TextField.TYPE_STORED));
                doc.Add(new Field("fieldname", "this", TextField.TYPE_STORED));

                var doc2 = new Document();
                var text2 = "This is the second text to be indexed.";
                doc2.Add(new Field("fieldname", text2, TextField.TYPE_STORED));
                doc2.Add(new Field("fieldname", "prova", TextField.TYPE_STORED));
                doc2.Add(new Field("fieldname", "this", TextField.TYPE_STORED));



                var doc3 = new Document();
                var tex3 = "ciao";
                doc3.Add(new Field("fieldname", tex3, TextField.TYPE_STORED));
                doc3.Add(new Field("fieldname", "ciao", TextField.TYPE_STORED));
                doc3.Add(new Field("fieldname", "this", TextField.TYPE_STORED));

                iwriter.AddDocument(doc);
                iwriter.AddDocument(doc2);
                iwriter.AddDocument(doc3);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<IEnumerable<SearchResult>> Search(string stringToSearch)
        {
            if (!DirectoryReader.IndexExists(_directory))
            {
                return new List<SearchResult>();
            }

            var ireader = DirectoryReader.Open(_directory);          
            var isearcher = new IndexSearcher(ireader);


           var parser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_CURRENT, "SearchableField", _analyzer);
            parser.AllowLeadingWildcard = true;
            var query = parser.Parse("*"+stringToSearch+"*");
            var hits = isearcher.Search(query, 1000);
            var searchResults = new List<SearchResult>();
            foreach (ScoreDoc scoreDoc in hits.ScoreDocs)
            {
                Document document = isearcher.Doc(scoreDoc.Doc);
                var result = new SearchResult()
                {
                    Id = document.Get("Id"),
                    SearchableString = document.Get("SearchableField"),
                    Type = document.Get("Type")
                };
                searchResults.Add(result);               
            }
            return searchResults;    
        }
    }
}
