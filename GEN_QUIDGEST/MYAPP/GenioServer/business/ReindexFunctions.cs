using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- PNLCOACHS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcoachs.FldCodcoachs)
                .From(CSGenioAcoachs.AreaCOACHS)
                .Where(CriteriaSet.And().In(CSGenioAcoachs.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcoachs model = new CSGenioAcoachs(user);
                model.ValCodcoachs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLGOALS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgoals.FldCodgoals)
                .From(CSGenioAgoals.AreaGOALS)
                .Where(CriteriaSet.And().In(CSGenioAgoals.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgoals model = new CSGenioAgoals(user);
                model.ValCodgoals = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLMATCHES --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmatches.FldCodmatches)
                .From(CSGenioAmatches.AreaMATCHES)
                .Where(CriteriaSet.And().In(CSGenioAmatches.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmatches model = new CSGenioAmatches(user);
                model.ValCodmatches = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLPLAYERS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAplayers.FldCodplayers)
                .From(CSGenioAplayers.AreaPLAYERS)
                .Where(CriteriaSet.And().In(CSGenioAplayers.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAplayers model = new CSGenioAplayers(user);
                model.ValCodplayers = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLREFEREES --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAreferees.FldCodreferees)
                .From(CSGenioAreferees.AreaREFEREES)
                .Where(CriteriaSet.And().In(CSGenioAreferees.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAreferees model = new CSGenioAreferees(user);
                model.ValCodreferees = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLSTADIUMS --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAstadiums.FldCodstadiums)
                .From(CSGenioAstadiums.AreaSTADIUMS)
                .Where(CriteriaSet.And().In(CSGenioAstadiums.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAstadiums model = new CSGenioAstadiums(user);
                model.ValCodstadiums = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- PNLTEAM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAteam.FldCodteam)
                .From(CSGenioAteam.AreaTEAM)
                .Where(CriteriaSet.And().In(CSGenioAteam.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAteam model = new CSGenioAteam(user);
                model.ValCodteam = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- PNLmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLmem")
                .Where(CriteriaSet.And().In("PNLmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLcfg")
                .Where(CriteriaSet.And().In("PNLcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLlstusr")
                .Where(CriteriaSet.And().In("PNLlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLlstcol")
                .Where(CriteriaSet.And().In("PNLlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLlstren")
                .Where(CriteriaSet.And().In("PNLlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLusrwid")
                .Where(CriteriaSet.And().In("PNLusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLusrcfg")
                .Where(CriteriaSet.And().In("PNLusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLusrset")
                .Where(CriteriaSet.And().In("PNLusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLwkfact")
                .Where(CriteriaSet.And().In("PNLwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLwkfcon")
                .Where(CriteriaSet.And().In("PNLwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLwkflig")
                .Where(CriteriaSet.And().In("PNLwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLwkflow")
                .Where(CriteriaSet.And().In("PNLwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLnotifi")
                .Where(CriteriaSet.And().In("PNLnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLprmfrm")
                .Where(CriteriaSet.And().In("PNLprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLscrcrd")
                .Where(CriteriaSet.And().In("PNLscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLpostit")
                .Where(CriteriaSet.And().In("PNLpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLalerta")
                .Where(CriteriaSet.And().In("PNLalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLaltent")
                .Where(CriteriaSet.And().In("PNLaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLtalert")
                .Where(CriteriaSet.And().In("PNLtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLdelega")
                .Where(CriteriaSet.And().In("PNLdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLTABDINAMIC")
                .Where(CriteriaSet.And().In("PNLTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLaltran")
                .Where(CriteriaSet.And().In("PNLaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLworkflowtask")
                .Where(CriteriaSet.And().In("PNLworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- PNLworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("PNLworkflowprocess")
                .Where(CriteriaSet.And().In("PNLworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}