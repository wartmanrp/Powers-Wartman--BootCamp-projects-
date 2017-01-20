// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// 
// ********************************************************************************************************************************************

using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Runtime.InteropServices;
using System.Transactions;
using Cts.Venture.Common;
using Cts.Venture.Common.Exceptions;
using System.Data.Entity.Core;

namespace Cts.Venture.Service
{
   /// <summary>
   /// The class provides transaction when there is need to add/update/delete multiple recores or that spans tables, databases or even instances.
   /// When used, the caller need to call CommitChanges() to commit the changes. Failed to call the function will result in rolling back all the
   /// changes even all the changes are valid.
   /// </summary>
   /// <typeparam name="T">Generic type.</typeparam>
   /// <history>
   /// Date       Author         Change Reason           Change Description
   /// --------------------------------------------------------------------------------------------------
   ///
   /// --------------------------------------------------------------------------------------------------
   /// </history>
   public class UnitOfWork<T> : IDisposable where T : DbContext
   {
      private readonly T _db;
      private readonly TransactionScope scope;

      /// <summary>
      /// Internal constructor to initialize transaction. 
      /// </summary>
      /// <param name="db">Generic type.</param>
      /// <history>
      /// Date       Author         Change Reason           Change Description
      /// --------------------------------------------------------------------------------------------------
      ///
      /// --------------------------------------------------------------------------------------------------
      /// </history>
      internal UnitOfWork(T db)
      {
         // get from container so it is part of lifetime scope shared by all other
         // repositories
         _db = db;

         scope = new TransactionScope();
      }

      /// <summary>
      /// Saves all the changes as an unit.
      /// </summary>
      /// <history>
      /// Date       Author         Change Reason           Change Description
      /// --------------------------------------------------------------------------------------------------
      ///
      /// --------------------------------------------------------------------------------------------------
      /// </history>
      public void CommitChanges()
      {
         try
         {
            // if an exception occurred, don't try and save, etc.
            if (Marshal.GetExceptionCode() == 0)
            {
               // catch all known exceptions that we can handle and convert to rules exception
               _db.SaveChanges();
               this.scope.Complete();
            }
         }
         catch (DbEntityValidationException val)
         {
            throw val.ToRulesException();
         }
         catch (OptimisticConcurrencyException) // in case our manual check didn't work? why?
         {
            throw new RulesException(string.Empty,
                @"The record has changed. Please cancel and try again");
         }
         catch (DbUpdateConcurrencyException)
         {
            throw new RulesException(string.Empty,
                @"The record has changed. Please cancel and try again");
         }
         finally
         {
            this.scope.Dispose();
         }
      }

      /// <summary>
      /// Disposes the transaction and its resources.
      /// </summary>
      /// <history>
      /// Date       Author         Change Reason           Change Description
      /// --------------------------------------------------------------------------------------------------
      ///
      /// --------------------------------------------------------------------------------------------------
      /// </history>
      public void Dispose()
      {
         this.scope.Dispose();
      }

   }
}
