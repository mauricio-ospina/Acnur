﻿
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using WinAdministrator.Common.Utils;
using WinAdministrator.Common.DataModel;

namespace WinAdministrator.Common.ViewModel
{
    /// <summary>
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    /// This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public abstract partial class SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork> : SingleObjectViewModelBase<TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// Initializes a new instance of the SingleObjectViewModel class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        /// <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        protected SingleObjectViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<TEntity, object> getEntityDisplayNameFunc = null)
            : base(unitOfWorkFactory, getRepositoryFunc, getEntityDisplayNameFunc)
        {
        }
    }

    public class SingleObjectViewModelState
    {
        public object[] Key { get; set; }
        public string Title { get; set; }
    }

    /// <summary>
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    /// It is not recommended to inherit directly from this class. Use the SingleObjectViewModel class instead.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    [POCOViewModel]
    public abstract class SingleObjectViewModelBase<TEntity, TPrimaryKey, TUnitOfWork> : ISingleObjectViewModel<TEntity, TPrimaryKey>, ISupportParameter, IDocumentContent, ISupportLogicalLayout<SingleObjectViewModelState>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {

        object title;
        protected readonly Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc;
        protected readonly Func<TEntity, object> getEntityDisplayNameFunc;
        Action<TEntity> entityInitializer;
        bool isEntityNewAndUnmodified;
        readonly Dictionary<string, IDocumentContent> lookUpViewModels = new Dictionary<string, IDocumentContent>();

        /// <summary>
        /// Initializes a new instance of the SingleObjectViewModelBase class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns repository representing entities of a given type.</param>
        /// <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        protected SingleObjectViewModelBase(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<TEntity, object> getEntityDisplayNameFunc)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            this.getRepositoryFunc = getRepositoryFunc;
            this.getEntityDisplayNameFunc = getEntityDisplayNameFunc;
            UpdateUnitOfWork();
            if (this.IsInDesignMode())
                this.Entity = this.Repository.FirstOrDefault();
            else
                OnInitializeInRuntime();
        }

        /// <summary>
        /// The display text for a given entity used as a title in the corresponding view.
        /// </summary>
        /// <returns></returns>
        public object Title { get { return title; } }

        /// <summary>
        /// An entity represented by this view model.
        /// Since SingleObjectViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        /// <returns></returns>
        public virtual TEntity Entity { get; protected set; }

        /// <summary>
        /// Updates the Title property value and raises CanExecute changed for relevant commands.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the UpdateCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public void Update()
        {
            isEntityNewAndUnmodified = false;
            UpdateTitle();
            UpdateCommands();
        }

        /// <summary>
        /// Saves changes in the underlying unit of work.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void Save()
        {
            SaveCore();
        }

        /// <summary>
        /// Determines whether entity has local changes that can be saved.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        /// </summary>
        public virtual bool CanSave()
        {
            return Entity != null && !HasValidationErrors() && NeedSave();
        }

        /// <summary>
        /// Saves changes in the underlying unit of work and closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndCloseCommand property that can be used as a binding source in views.
        /// </summary>
        [Command(CanExecuteMethodName = "CanSave")]
        public void SaveAndClose()
        {
            if (SaveCore())
                Close();
        }

        /// <summary>
        /// Saves changes in the underlying unit of work and create new entity.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndNewCommand property that can be used as a binding source in views.
        /// </summary>
        [Command(CanExecuteMethodName = "CanSave")]
        public void SaveAndNew()
        {
            if (SaveCore())
                CreateAndInitializeEntity(this.entityInitializer);
        }

        /// <summary>
        /// Reset entity local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the ResetCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(Name = "Reset Changes")]
        public void Reset()
        {
            MessageResult confirmationResult = MessageBoxService.ShowMessage(CommonResources.Confirmation_Reset, CommonResources.Confirmation_Caption, MessageButton.OKCancel);
            if (confirmationResult == MessageResult.OK)
                Reload();
        }

        /// <summary>
        /// Determines whether entity has local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for ResetCommand.
        /// </summary>
        public bool CanReset()
        {
            return NeedReset();
        }

        string ViewName { get { return typeof(TEntity).Name + "View"; } }

        /// <summary>
        /// The display name of TEntity to be used when presenting messages to the user.
        /// </summary>
        public virtual string EntityDisplayName { get { return typeof(TEntity).Name; } }

        [DXImage("Save")]
        [Display(Name = "Save Layout")]
        public void SaveLayout()
        {
            PersistentLayoutHelper.TrySerializeLayout(LayoutSerializationService, ViewName);
            PersistentLayoutHelper.SaveLayout();
        }

        [DXImage("Reset")]
        [Display(Name = "Reset Layout")]
        public void ResetLayout()
        {
            if (LayoutSerializationService != null)
                LayoutSerializationService.Deserialize(null);
        }

        [Display(AutoGenerateField = false)]
        public virtual void OnLoaded()
        {
            PersistentLayoutHelper.TryDeserializeLayout(LayoutSerializationService, ViewName);
        }

        /// <summary>
        /// Deletes the entity, save changes and closes the corresponding view if confirmed by a user.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void Delete()
        {
            if (MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Delete, EntityDisplayName), GetConfirmationMessageTitle(), MessageButton.YesNo) != MessageResult.Yes)
                return;
            try
            {
                OnBeforeEntityDeleted(PrimaryKey, Entity);
                Repository.Remove(Entity);
                UnitOfWork.SaveChanges();
                TPrimaryKey primaryKeyForMessage = PrimaryKey;
                TEntity entityForMessage = Entity;
                Entity = null;
                OnEntityDeleted(primaryKeyForMessage, entityForMessage);
                Close();
            }
            catch (DbException e)
            {
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Determines whether the entity can be deleted.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        /// </summary>
        public virtual bool CanDelete()
        {
            return Entity != null && !IsNew();
        }

        /// <summary>
        /// Closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the CloseCommand property that can be used as a binding source in views.
        /// </summary>
        public void Close()
        {
            if (!TryClose())
                return;
            if (DocumentOwner != null)
                DocumentOwner.Close(this);
        }

        protected IUnitOfWorkFactory<TUnitOfWork> UnitOfWorkFactory { get; private set; }

        protected TUnitOfWork UnitOfWork { get; private set; }

        protected virtual bool SaveCore()
        {
            try
            {
                bool isNewEntity = IsNew();
                if (!isNewEntity)
                {
                    Repository.SetPrimaryKey(Entity, PrimaryKey);
                    Repository.Update(Entity);
                }
                OnBeforeEntitySaved(PrimaryKey, Entity, isNewEntity);
                UnitOfWork.SaveChanges();
                LoadEntityByKey(Repository.GetPrimaryKey(Entity));
                OnEntitySaved(PrimaryKey, Entity, isNewEntity);
                this.RaisePropertyChanged(x => x.IsPrimaryKeyReadOnly);
                return true;
            }
            catch (DbException e)
            {
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.Error);
                return false;
            }
        }

        protected virtual void OnBeforeEntitySaved(TPrimaryKey primaryKey, TEntity entity, bool isNewEntity) { }

        protected virtual void OnEntitySaved(TPrimaryKey primaryKey, TEntity entity, bool isNewEntity)
        {
            Messenger.Default.Send(new EntityMessage<TEntity, TPrimaryKey>(primaryKey, isNewEntity ? EntityMessageType.Added : EntityMessageType.Changed, this));
        }

        protected virtual void OnBeforeEntityDeleted(TPrimaryKey primaryKey, TEntity entity) { }

        protected virtual void OnEntityDeleted(TPrimaryKey primaryKey, TEntity entity)
        {
            Messenger.Default.Send(new EntityMessage<TEntity, TPrimaryKey>(primaryKey, EntityMessageType.Deleted));
        }

        protected virtual void OnInitializeInRuntime()
        {
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(this, x => OnEntityMessage(x));
            Messenger.Default.Register<SaveAllMessage>(this, x => Save());
            Messenger.Default.Register<CloseAllMessage>(this, m =>
            {
                if (m.ShouldProcess(this))
                {
                    OnClosing(m);
                }
            });
        }

        protected virtual void OnEntityMessage(EntityMessage<TEntity, TPrimaryKey> message)
        {
            if (Entity == null) return;
            if (message.MessageType == EntityMessageType.Deleted && object.Equals(message.PrimaryKey, PrimaryKey))
                Close();
        }

        protected virtual void OnEntityChanged()
        {
            if (Entity != null && Repository.HasPrimaryKey(Entity))
            {
                PrimaryKey = Repository.GetPrimaryKey(Entity);
                RefreshLookUpCollections(true);
            }
            Update();
        }

        protected IRepository<TEntity, TPrimaryKey> Repository { get { return getRepositoryFunc(UnitOfWork); } }

        protected TPrimaryKey PrimaryKey { get; private set; }

        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }
        protected ILayoutSerializationService LayoutSerializationService { get { return this.GetService<ILayoutSerializationService>(); } }


        protected virtual void OnParameterChanged(object parameter)
        {
            var initializer = parameter as Action<TEntity>;
            if (initializer != null)
                CreateAndInitializeEntity(initializer);
            else if (parameter is TPrimaryKey)
                LoadEntityByKey((TPrimaryKey)parameter);
            else
                Entity = null;
        }

        protected virtual TEntity CreateEntity()
        {
            return Repository.Create();
        }

        protected void Reload()
        {
            if (Entity == null || IsNew())
                CreateAndInitializeEntity(this.entityInitializer);
            else
                LoadEntityByKey(PrimaryKey);
        }

        protected void CreateAndInitializeEntity(Action<TEntity> entityInitializer)
        {
            UpdateUnitOfWork();
            this.entityInitializer = entityInitializer;
            var entity = CreateEntity();
            if (this.entityInitializer != null)
                this.entityInitializer(entity);
            Entity = entity;
            isEntityNewAndUnmodified = true;
        }

        protected void LoadEntityByKey(TPrimaryKey primaryKey)
        {
            UpdateUnitOfWork();
            Entity = Repository.Find(primaryKey);
        }

        void UpdateUnitOfWork()
        {
            UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
        }

        void UpdateTitle(string nullEntityValue = null)
        {
            if (Entity == null)
                title = nullEntityValue;
            else if (IsNew())
                title = GetTitleForNewEntity();
            else
                title = GetTitle(GetState() == EntityState.Modified);
            this.RaisePropertyChanged(x => x.Title);
        }

        protected virtual void UpdateCommands()
        {
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.SaveAndClose());
            this.RaiseCanExecuteChanged(x => x.SaveAndNew());
            this.RaiseCanExecuteChanged(x => x.Delete());
            this.RaiseCanExecuteChanged(x => x.Reset());
        }

        protected IDocumentOwner DocumentOwner { get; private set; }

        protected virtual void OnDestroy()
        {
            Messenger.Default.Unregister(this);
            RefreshLookUpCollections(false);
        }

        protected virtual bool TryClose()
        {
            if (HasValidationErrors())
            {
                MessageResult warningResult = MessageBoxService.ShowMessage(CommonResources.Warning_SomeFieldsContainInvalidData, CommonResources.Warning_Caption, MessageButton.OKCancel);
                return warningResult == MessageResult.OK;
            }
            if (!NeedReset()) return true;
            MessageResult result = MessageBoxService.ShowMessage(CommonResources.Confirmation_Save, GetConfirmationMessageTitle(), MessageButton.YesNoCancel);
            if (result == MessageResult.Yes)
                return SaveCore();
            if (result == MessageResult.No)
                Reload();
            return result != MessageResult.Cancel;
        }

        protected virtual void OnClosing(CloseAllMessage message)
        {
            if (!message.Cancel)
                message.Cancel = !TryClose();
        }

        protected virtual string GetConfirmationMessageTitle()
        {
            return GetTitle();
        }

        public bool IsNew()
        {
            return Entity != null && GetState() == EntityState.Added;
        }

        public bool IsPrimaryKeyReadOnly
        {
            get { return !IsNew(); }
        }

        protected virtual bool NeedSave()
        {
            if (Entity == null)
                return false;
            EntityState state = GetState();
            return state == EntityState.Modified || state == EntityState.Added;
        }

        protected virtual bool NeedReset()
        {
            return NeedSave() && !isEntityNewAndUnmodified;
        }

        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = Entity as IDataErrorInfo;
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }

        string GetTitle(bool entityModified)
        {
            return GetTitle() + (entityModified ? CommonResources.Entity_Changed : string.Empty);
        }

        protected virtual string GetTitleForNewEntity()
        {
            return EntityDisplayName + CommonResources.Entity_New;
        }

        protected virtual string GetTitle()
        {
            return (EntityDisplayName + " - " + Convert.ToString(getEntityDisplayNameFunc != null ? getEntityDisplayNameFunc(Entity) : PrimaryKey))
            .Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        }

        protected EntityState GetState()
        {
            try
            {
                return Repository.GetState(Entity);
            }
            catch (InvalidOperationException)
            {
                Repository.SetPrimaryKey(Entity, PrimaryKey);
                return Repository.GetState(Entity);
            }

        }

        #region look up and detail view models
        protected virtual void RefreshLookUpCollections(bool raisePropertyChanged)
        {
            var values = lookUpViewModels.ToArray();
            lookUpViewModels.Clear();
            foreach (var item in values)
            {
                item.Value.OnDestroy();
                if (raisePropertyChanged)
                    ((IPOCOViewModel)this).RaisePropertyChanged(item.Key);
            }
            OnLookupCollectionsUpdated();
        }

        protected virtual void OnLookupCollectionsUpdated() { }

        protected AddRemoveDetailEntitiesViewModel<TEntity, TPrimaryKey, TDetailEntity, TDetailPrimaryKey, TUnitOfWork>
            CreateAddRemoveDetailEntitiesViewModel<TDetailEntity, TDetailPrimaryKey>(Func<TUnitOfWork, IRepository<TDetailEntity, TDetailPrimaryKey>> getDetailsRepositoryFunc, Func<TEntity, ICollection<TDetailEntity>> getDetailsFunc)
            where TDetailEntity : class
        {
            var viewModel = AddRemoveDetailEntitiesViewModel<TEntity, TPrimaryKey, TDetailEntity, TDetailPrimaryKey, TUnitOfWork>.Create(UnitOfWorkFactory, this.getRepositoryFunc, getDetailsRepositoryFunc, getDetailsFunc, PrimaryKey);
            viewModel.SetParentViewModel(this);
            return viewModel;
        }

        protected AddRemoveJunctionDetailEntitiesViewModel<TEntity, TPrimaryKey, TDetailEntity, TDetailPrimaryKey, TJunction, TJunctionPrimaryKey, TUnitOfWork>
            CreateAddRemoveJunctionDetailEntitiesViewModel<TDetailEntity, TDetailPrimaryKey, TJunction, TJunctionPrimaryKey>(
                Func<TUnitOfWork, IRepository<TDetailEntity, TDetailPrimaryKey>> getDetailsRepositoryFunc,
                Func<TUnitOfWork, IRepository<TJunction, TJunctionPrimaryKey>> getJunctionRepositoryFunc,
                Expression<Func<TJunction, TPrimaryKey>> getEntityForeignKey,
                Expression<Func<TJunction, TDetailPrimaryKey>> getDetailForeignKey)
            where TDetailEntity : class
            where TJunction : class, new()
            where TJunctionPrimaryKey : class
        {
            var viewModel = AddRemoveJunctionDetailEntitiesViewModel<TEntity, TPrimaryKey, TDetailEntity, TDetailPrimaryKey, TJunction, TJunctionPrimaryKey, TUnitOfWork>
                .CreateViewModel(UnitOfWorkFactory, this.getRepositoryFunc, getDetailsRepositoryFunc, getJunctionRepositoryFunc, getEntityForeignKey, getDetailForeignKey, PrimaryKey);
            viewModel.SetParentViewModel(this);
            return viewModel;
        }

        protected CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork> GetDetailsCollectionViewModel<TViewModel, TDetailEntity, TDetailPrimaryKey, TForeignKey>(
            Expression<Func<TViewModel, CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork>>> propertyExpression,
            Func<TUnitOfWork, IRepository<TDetailEntity, TDetailPrimaryKey>> getRepositoryFunc,
            Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression,
            Action<TDetailEntity, TPrimaryKey> setMasterEntityKeyAction,
            Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailEntity>> projection = null) where TDetailEntity : class
        {
            return GetCollectionViewModelCore<CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork>, TDetailEntity, TDetailEntity, TForeignKey>(propertyExpression,
                () => CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork>.CreateCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate<TDetailEntity, TDetailEntity, TForeignKey>(foreignKeyExpression, projection), CreateForeignKeyPropertyInitializer(setMasterEntityKeyAction, () => PrimaryKey), () => CanCreateNewEntity(), true));
        }

        protected CollectionViewModel<TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork> GetDetailProjectionsCollectionViewModel<TViewModel, TDetailEntity, TDetailProjection, TDetailPrimaryKey, TForeignKey>(
            Expression<Func<TViewModel, CollectionViewModel<TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork>>> propertyExpression,
            Func<TUnitOfWork, IRepository<TDetailEntity, TDetailPrimaryKey>> getRepositoryFunc,
            Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression,
            Action<TDetailEntity, TPrimaryKey> setMasterEntityKeyAction,
            Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailProjection>> projection = null)
            where TDetailEntity : class
            where TDetailProjection : class
        {
            return GetCollectionViewModelCore<CollectionViewModel<TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork>, TDetailEntity, TDetailProjection, TForeignKey>(propertyExpression,
                () => CollectionViewModel<TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork>.CreateProjectionCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate<TDetailEntity, TDetailProjection, TForeignKey>(foreignKeyExpression, projection), CreateForeignKeyPropertyInitializer(setMasterEntityKeyAction, () => PrimaryKey), () => CanCreateNewEntity(), true));
        }


        protected ReadOnlyCollectionViewModel<TDetailEntity, TUnitOfWork> GetReadOnlyDetailsCollectionViewModel<TViewModel, TDetailEntity, TForeignKey>(
            Expression<Func<TViewModel, ReadOnlyCollectionViewModel<TDetailEntity, TDetailEntity, TUnitOfWork>>> propertyExpression,
            Func<TUnitOfWork, IReadOnlyRepository<TDetailEntity>> getRepositoryFunc,
            Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression,
            Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailEntity>> projection = null) where TDetailEntity : class
        {
            return GetCollectionViewModelCore<ReadOnlyCollectionViewModel<TDetailEntity, TUnitOfWork>, TDetailEntity, TDetailEntity, TForeignKey>(propertyExpression, () => ReadOnlyCollectionViewModel<TDetailEntity, TUnitOfWork>.CreateReadOnlyCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate<TDetailEntity, TDetailEntity, TForeignKey>(foreignKeyExpression, projection)));
        }

        protected ReadOnlyCollectionViewModel<TDetailEntity, TDetailProjection, TUnitOfWork> GetReadOnlyDetailProjectionsCollectionViewModel<TViewModel, TDetailEntity, TDetailProjection, TForeignKey>(
            Expression<Func<TViewModel, ReadOnlyCollectionViewModel<TDetailEntity, TDetailProjection, TUnitOfWork>>> propertyExpression,
            Func<TUnitOfWork, IReadOnlyRepository<TDetailEntity>> getRepositoryFunc,
            Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression,
            Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailProjection>> projection)
            where TDetailEntity : class
            where TDetailProjection : class
        {
            return GetCollectionViewModelCore<ReadOnlyCollectionViewModel<TDetailEntity, TDetailProjection, TUnitOfWork>, TDetailEntity, TDetailProjection, TForeignKey>(propertyExpression, () => ReadOnlyCollectionViewModel<TDetailEntity, TDetailProjection, TUnitOfWork>.CreateReadOnlyProjectionCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate<TDetailEntity, TDetailProjection, TForeignKey>(foreignKeyExpression, projection)));
        }

        Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailProjection>> AppendForeignKeyPredicate<TDetailEntity, TDetailProjection, TForeignKey>(
            Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression,
            Func<IRepositoryQuery<TDetailEntity>, IQueryable<TDetailProjection>> projection)
            where TDetailEntity : class
            where TDetailProjection : class
        {
            var predicate = ExpressionHelper.GetKeyEqualsExpression<TDetailEntity, TDetailEntity, TForeignKey>(foreignKeyExpression, (TForeignKey)(object)PrimaryKey);
            return ReadOnlyRepositoryExtensions.AppendToProjection<TDetailEntity, TDetailProjection>(predicate, projection);
        }

        protected IEntitiesViewModel<TLookUpEntity> GetLookUpEntitiesViewModel<TViewModel, TLookUpEntity, TLookUpEntityKey>(Expression<Func<TViewModel, IEntitiesViewModel<TLookUpEntity>>> propertyExpression, Func<TUnitOfWork, IRepository<TLookUpEntity, TLookUpEntityKey>> getRepositoryFunc, Func<IRepositoryQuery<TLookUpEntity>, IQueryable<TLookUpEntity>> projection = null) where TLookUpEntity : class
        {
            return GetLookUpProjectionsViewModel(propertyExpression, getRepositoryFunc, projection);
        }

        protected virtual IEntitiesViewModel<TLookUpProjection> GetLookUpProjectionsViewModel<TViewModel, TLookUpEntity, TLookUpProjection, TLookUpEntityKey>(Expression<Func<TViewModel, IEntitiesViewModel<TLookUpProjection>>> propertyExpression, Func<TUnitOfWork, IRepository<TLookUpEntity, TLookUpEntityKey>> getRepositoryFunc, Func<IRepositoryQuery<TLookUpEntity>, IQueryable<TLookUpProjection>> projection)
            where TLookUpEntity : class
            where TLookUpProjection : class
        {
            return GetEntitiesViewModelCore<IEntitiesViewModel<TLookUpProjection>, TLookUpProjection>(propertyExpression, () => LookUpEntitiesViewModel<TLookUpEntity, TLookUpProjection, TLookUpEntityKey, TUnitOfWork>.Create(UnitOfWorkFactory, getRepositoryFunc, projection));
        }

        Action<TDetailEntity> CreateForeignKeyPropertyInitializer<TDetailEntity, TForeignKey>(Action<TDetailEntity, TPrimaryKey> setMasterEntityKeyAction, Func<TForeignKey> getMasterEntityKey) where TDetailEntity : class
        {
            return x => setMasterEntityKeyAction(x, (TPrimaryKey)(object)getMasterEntityKey());
        }

        protected virtual bool CanCreateNewEntity()
        {
            if (Entity == null)
                return false;
            if (!IsNew())
                return true;
            string message = string.Format(CommonResources.Confirmation_SaveParent, EntityDisplayName);
            var result = MessageBoxService.ShowMessage(message, CommonResources.Confirmation_Caption, MessageButton.YesNo);
            return result == MessageResult.Yes && SaveCore();
        }

        TViewModel GetCollectionViewModelCore<TViewModel, TDetailEntity, TDetailProjection, TForeignKey>(
            LambdaExpression propertyExpression,
            Func<TViewModel> createViewModelCallback)
            where TViewModel : IDocumentContent
            where TDetailEntity : class
            where TDetailProjection : class
        {
            return GetEntitiesViewModelCore<TViewModel, TDetailProjection>(propertyExpression, () =>
            {
                var viewModel = createViewModelCallback();
                viewModel.SetParentViewModel(this);
                return viewModel;
            });
        }

        TViewModel GetEntitiesViewModelCore<TViewModel, TDetailEntity>(LambdaExpression propertyExpression, Func<TViewModel> createViewModelCallback)
            where TViewModel : IDocumentContent
            where TDetailEntity : class
        {

            IDocumentContent result = null;
            string propertyName = ExpressionHelper.GetPropertyName(propertyExpression);
            if (!lookUpViewModels.TryGetValue(propertyName, out result))
            {
                result = createViewModelCallback();
                lookUpViewModels[propertyName] = result;
            }
            return (TViewModel)result;
        }
        #endregion

        #region ISupportParameter
        object ISupportParameter.Parameter
        {
            get { return null; }
            set { OnParameterChanged(value); }
        }
        #endregion

        #region IDocumentContent
        object IDocumentContent.Title { get { return Title; } }

        void IDocumentContent.OnClose(CancelEventArgs e)
        {
            e.Cancel = !TryClose();
            Messenger.Default.Send(new DestroyOrphanedDocumentsMessage());
        }

        void IDocumentContent.OnDestroy()
        {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner
        {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        #endregion

        #region ISingleObjectViewModel
        TEntity ISingleObjectViewModel<TEntity, TPrimaryKey>.Entity { get { return Entity; } }

        TPrimaryKey ISingleObjectViewModel<TEntity, TPrimaryKey>.PrimaryKey { get { return PrimaryKey; } }
        #endregion

        #region ISupportLogicalLayout
        bool ISupportLogicalLayout.CanSerialize
        {
            get { return Entity != null && !IsNew(); }
        }

        SingleObjectViewModelState ISupportLogicalLayout<SingleObjectViewModelState>.SaveState()
        {
            return new SingleObjectViewModelState
            {
                Key = ExpressionHelper.GetKeyPropertyValues(PrimaryKey),
                Title = GetTitle(false)
            };
        }

        void ISupportLogicalLayout<SingleObjectViewModelState>.RestoreState(SingleObjectViewModelState state)
        {
            var key = ExpressionHelper.IsTuple<TPrimaryKey>()
                    ? ExpressionHelper.MakeTuple<TPrimaryKey>(state.Key)
                    : (TPrimaryKey)state.Key.First();
            LoadEntityByKey(key);
            if (Entity == null)
                UpdateTitle(state.Title + CommonResources.Entity_Deleted);
        }

        IDocumentManagerService ISupportLogicalLayout.DocumentManagerService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        IEnumerable<object> ISupportLogicalLayout.LookupViewModels
        {
            get { return lookUpViewModels.Values; }
        }
        #endregion
    }
}