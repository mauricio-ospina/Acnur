﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;

namespace WinAdministrator.Common.ViewModel
{
    /// <summary>
    /// Provides the extension methods that are used to implement the IDocumentManagerService interface.
    /// </summary>
    public static class DocumentManagerServiceExtensions
    {
        /// <summary>
        /// Creates and shows a document containing a single object view model for the existing entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        /// <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        /// <param name="primaryKey">An entity primary key.</param>
        public static IDocument ShowExistingEntityDocument<TEntity, TPrimaryKey>(this IDocumentManagerService documentManagerService, object parentViewModel, TPrimaryKey primaryKey)
        {
            IDocument document = FindEntityDocument<TEntity, TPrimaryKey>(documentManagerService, primaryKey) ?? CreateDocument<TEntity>(documentManagerService, primaryKey, parentViewModel);
            if (document != null)
                document.Show();
            return document;
        }

        /// <summary>
        /// Creates and shows a document containing a single object view model for new entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        /// <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        /// <param name="newEntityInitializer">An optional parameter that provides a function that initializes a new entity.</param>
        public static void ShowNewEntityDocument<TEntity>(this IDocumentManagerService documentManagerService, object parentViewModel, Action<TEntity> newEntityInitializer = null)
        {
            IDocument document = CreateDocument<TEntity>(documentManagerService, newEntityInitializer ?? (x => DefaultEntityInitializer(x)), parentViewModel);
            if (document != null)
                document.Show();
        }

        /// <summary>
        /// Searches for a document that contains a single object view model editing entity with a specified primary key.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to find a document.</param>
        /// <param name="primaryKey">An entity primary key.</param>
        public static IDocument FindEntityDocument<TEntity, TPrimaryKey>(this IDocumentManagerService documentManagerService, TPrimaryKey primaryKey)
        {
            if (documentManagerService == null)
                return null;
            foreach (IDocument document in documentManagerService.Documents)
            {
                ISingleObjectViewModel<TEntity, TPrimaryKey> entityViewModel = document.Content as ISingleObjectViewModel<TEntity, TPrimaryKey>;
                if (entityViewModel != null && object.Equals(entityViewModel.PrimaryKey, primaryKey))
                    return document;
            }
            return null;
        }

        static void DefaultEntityInitializer<TEntity>(TEntity entity) { }

        static IDocument CreateDocument<TEntity>(IDocumentManagerService documentManagerService, object parameter, object parentViewModel)
        {
            if (documentManagerService == null)
                return null;
            var document = documentManagerService.CreateDocument(GetDocumentTypeName<TEntity>(), parameter, parentViewModel);
            document.Id = "_" + Guid.NewGuid().ToString().Replace('-', '_');
            document.DestroyOnClose = false;
            return document;
        }

        public static string GetDocumentTypeName<TEntity>()
        {
            return typeof(TEntity).Name + "View";
        }
    }
}