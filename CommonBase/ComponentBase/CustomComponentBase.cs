﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBase.Dtos;
using CommonBase.Models;
using CommonBase.Services;
using CommonBase.Shared.Services;
using CommonBase.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

namespace CommonBase.ComponentBase
{
    public class CustomComponentBase<T, TDto> : Microsoft.AspNetCore.Components.ComponentBase
        where T : BaseModelApp, new()
        where TDto : DtosBase, new()
    {

        [Inject]
        public ServiceBase<T, TDto> _service { get; set; }

        [Inject]
        public NotificationService Ns { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public SpinnerService spinnerService { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }


        protected bool allowVirtualization { get; set; }
        protected bool isLoading { get; set; }
        protected List<TDto>? DataList { get; set; }
        protected int from { get; set; } = 0;
        protected int to { get; set; } = 0;
        protected int PageSize { get; set; } = 5;
        protected int count { get; set; }
        protected string searchCriteria { get; set; } = "";
        protected string pathRedirectNew { get; set; } = "";
        protected string MsjDeleteIttem { get; set; } = "";
        protected string MsjDeleteIttemOK { get; set; } = "";
        protected string MsjDeleteIttemTitle { get; set; } = "";
        protected string AditionalParamUrl { get; set; } = "";
        protected Dictionary<string, string> AditionalParmFilter  { get; set; }
        protected string FieldExtraFilter { get; set; } = "";
        protected string ValueExtraFilter { get; set; } = "";


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            try
            {
                  await LoadInitialData();
            }
            catch (Exception ex)
            {
                AppUtils.ShowNotify(ex.Message, "ERROR", Ns);
            }

        }
        protected async void Editar(int id)
        {
            if (string.IsNullOrWhiteSpace(AditionalParamUrl))
            {
                Navigation.NavigateTo($"{pathRedirectNew}/{id}");
            }
            else { 
                Navigation.NavigateTo($"{pathRedirectNew}/{id}/{AditionalParamUrl}");
            }

        }
        protected void IrANuevo()
        {
            if (string.IsNullOrWhiteSpace(AditionalParamUrl))
            {
                Navigation.NavigateTo(pathRedirectNew);
            }
            else
            {
                Navigation.NavigateTo($"{pathRedirectNew}/{AditionalParamUrl}");
            }
            
        }
        protected virtual async Task LoadData(int? from, int? to)
        {
            isLoading = true;
            try
            {
                Dictionary<string, string> extraParm = null;
                if (!string.IsNullOrWhiteSpace(FieldExtraFilter) && !string.IsNullOrWhiteSpace(ValueExtraFilter))
                {
                    extraParm = new Dictionary<string, string>() { { FieldExtraFilter, ValueExtraFilter } };
                }
                count = await _service.GetCount(searchCriteria, extraParm);
                DataList = await _service.GetAll(from, to, searchCriteria, extraParm);
            }
            catch (Exception ex)
            {
                AppUtils.ShowNotify($"ERROR : {ex.Message} ", "WARNING", Ns);
            }
            finally
            {
                isLoading = false;
            }

        }
        protected async Task LoadDataGrig(LoadDataArgs args)
        {
            var fromTo = AppUtils.GetFromTo(args?.Top, args?.Skip);
            await LoadData(fromTo.From, fromTo.To);
        }
        protected async void Detete(int id)
        {
            bool result = false;
            try
            {
                result = await AppUtils.ShowConfirm(MsjDeleteIttemTitle, MsjDeleteIttem, DialogService);

            }
            catch (Exception ex)
            {
                AppUtils.ShowNotify($"ERROR : {ex.Message} ", "WARNING", Ns);
            }


            if ((bool)result)
            {
                spinnerService.Show();
                try
                {
                    await _service.Delete(id);
                    await LoadInitialData();
                    StateHasChanged();
                    AppUtils.ShowNotify(MsjDeleteIttemOK, "OK", Ns);
                }
                catch (Exception ex)
                {
                    AppUtils.ShowNotify($"ERROR : {ex.Message} ", "WARNING", Ns);
                }
                finally
                {
                    spinnerService.Hide();
                }

            }
        }
        protected async Task LoadInitialData()
        {
            await LoadData(0, PageSize - 1);
        }
        protected virtual async Task Buscar()
        {
            await LoadInitialData();
            StateHasChanged();
        }
        protected async void OnChange(string value)
        {
            searchCriteria = value;
            if (string.IsNullOrWhiteSpace(value))
            {
                await Buscar();
            }
        }

        protected async Task SearchInputKeyPressed(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                await Buscar();
            }
        }
    }
}
