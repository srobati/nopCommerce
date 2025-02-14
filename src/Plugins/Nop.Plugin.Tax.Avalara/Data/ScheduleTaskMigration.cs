﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentMigrator;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.ScheduleTasks;

namespace Nop.Plugin.Tax.Avalara.Data
{
    [NopMigration("2021-12-06 00:00:00", "Tax.Avalara 2.60. New schedule task", MigrationProcessType.Update)]
    public class ScheduleTaskMigration : MigrationBase
    {
        #region Fields

        private readonly AvalaraTaxSettings _avalaraTaxSettings;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly IScheduleTaskService _scheduleTaskService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public ScheduleTaskMigration(AvalaraTaxSettings avalaraTaxSettings,
            ILanguageService languageService,
            ILocalizationService localizationService,
            IScheduleTaskService scheduleTaskService,
            ISettingService settingService)
        {
            _avalaraTaxSettings = avalaraTaxSettings;
            _languageService = languageService;
            _localizationService = localizationService;
            _scheduleTaskService = scheduleTaskService;
            _settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //locales
            var languages = _languageService.GetAllLanguagesAsync(true).Result;
            var languageId = languages
                .FirstOrDefault(lang => lang.UniqueSeoCode == new CultureInfo(NopCommonDefaults.DefaultLanguageCulture).TwoLetterISOLanguageName)
                ?.Id;

            _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Tax.Avalara.Fields.UseTaxRateTables"] = "Use tax rate tables to estimate ",
                ["Plugins.Tax.Avalara.Fields.UseTaxRateTables.Hint"] = "Determine whether to use tax rate tables to estimate. This will be used as a default tax calculation for catalog pages and will be adjusted and reconciled to the final transaction tax during checkout. Tax rates are looked up by zip code (US only) in a file that will be periodically updated from the Avalara (see Schedule tasks).",
            }, languageId).Wait();

            //settings
            if (!_settingService.SettingExistsAsync(_avalaraTaxSettings, settings => settings.UseTaxRateTables).Result)
                _avalaraTaxSettings.UseTaxRateTables = true;
            _settingService.SaveSettingAsync(_avalaraTaxSettings).Wait();

            //schedule task
            if (_scheduleTaskService.GetTaskByTypeAsync(AvalaraTaxDefaults.DownloadTaxRatesTask.Type).Result is null)
            {
                _scheduleTaskService.InsertTaskAsync(new()
                {
                    Enabled = true,
                    LastEnabledUtc = DateTime.UtcNow,
                    Seconds = AvalaraTaxDefaults.DownloadTaxRatesTask.Days * 24 * 60 * 60,
                    Name = AvalaraTaxDefaults.DownloadTaxRatesTask.Name,
                    Type = AvalaraTaxDefaults.DownloadTaxRatesTask.Type
                }).Wait();
            }
        }

        /// <summary>
        /// Collects the DOWN migration expressions
        /// </summary>
        public override void Down()
        {
            //nothing
        }

        #endregion
    }
}