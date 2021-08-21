using System;

using UnityEngine;

using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Game.Formulas;
using DaggerfallWorkshop.Utility.AssetInjection;

class UnleveledSpellEffectEditor : DaggerfallEffectSettingsEditorWindow
{
    protected TextLabel goldCostLabel;

    #region Constructors

    public UnleveledSpellEffectEditor(IUserInterfaceManager uiManager, DaggerfallBaseWindow previous = null)
        : base(uiManager, previous)
    {
    }

    #endregion

    #region Setup Methods
    protected override void Setup()
    {
        // Load all the textures used by effect editor window
        LoadTextures();

        // Setup native panel background
        NativePanel.BackgroundTexture = baseTexture;

        // Setup controls
        SetupEffectDescriptionPanels();

        exitButtonRect = new Rect(251, 147, 24, 16);

        durationBaseSpinnerRect = new Rect(94, 106, spinnerWidth, spinnerHeight);
        chanceBaseSpinnerRect = new Rect(94, 126, spinnerWidth, spinnerHeight);
        magnitudeBaseMinSpinnerRect = new Rect(94, 146, spinnerWidth, spinnerHeight);
        magnitudeBaseMaxSpinnerRect = new Rect(134, 146, spinnerWidth, spinnerHeight);

        SetupSpinners();

        SetupButtons();
        InitControlState();

        // Spell cost label
        goldCostLabel = DaggerfallUI.AddTextLabel(DaggerfallUI.DefaultFont, new Vector2(244, 112), string.Empty, NativePanel);
        spellCostLabel = DaggerfallUI.AddTextLabel(DaggerfallUI.DefaultFont, new Vector2(244, 132), string.Empty, NativePanel);

        IsSetup = true;
        UpdateCosts();
    }

    protected override void LoadTextures()
    {
        // Load source textures
        TextureReplacement.TryImportImage("UnleveledSpellEffectEditorMask.png", true, out baseTexture);
    }

    protected override void SetupEffectDescriptionPanels()
    {
        // Create parent panel to house effect description
        Panel descriptionParentPanel = DaggerfallUI.AddPanel(new Rect(5, 31, 312, 69), NativePanel);
        descriptionParentPanel.HorizontalAlignment = HorizontalAlignment.Center;

        // Create description panel centred inside of parent
        descriptionPanel = DaggerfallUI.AddPanel(descriptionParentPanel, AutoSizeModes.None);
        descriptionPanel.Size = new Vector2(306, 69);
        descriptionPanel.HorizontalAlignment = HorizontalAlignment.Center;
        descriptionPanel.VerticalAlignment = VerticalAlignment.Middle;
        DaggerfallUI.Instance.SetDaggerfallPopupStyle(DaggerfallUI.PopupStyle.Parchment, descriptionPanel);

        // Create multiline label for description text
        descriptionLabel = new MultiFormatTextLabel();
        descriptionLabel.HorizontalAlignment = HorizontalAlignment.Center;
        descriptionLabel.VerticalAlignment = VerticalAlignment.Middle;
        descriptionPanel.Components.Add(descriptionLabel);
    }

    #endregion

    #region Helpers

    #endregion

    #region Protected Methods

    protected override void SetupSpinners()
    {
        // Add spinner controls
        durationBaseSpinner = new UpDownSpinner(durationBaseSpinnerRect, spinnerUpButtonRect, spinnerDownButtonRect, spinnerValueLabelRect, 0, null, NativePanel);
        chanceBaseSpinner = new UpDownSpinner(chanceBaseSpinnerRect, spinnerUpButtonRect, spinnerDownButtonRect, spinnerValueLabelRect, 0, null, NativePanel);
        magnitudeBaseMinSpinner = new UpDownSpinner(magnitudeBaseMinSpinnerRect, spinnerUpButtonRect, spinnerDownButtonRect, spinnerValueLabelRect, 0, null, NativePanel);
        magnitudeBaseMaxSpinner = new UpDownSpinner(magnitudeBaseMaxSpinnerRect, spinnerUpButtonRect, spinnerDownButtonRect, spinnerValueLabelRect, 0, null, NativePanel);
        
        // Set spinner mouse over colours
        durationBaseSpinner.SetMouseOverBackgroundColor(hotButtonColor);
        chanceBaseSpinner.SetMouseOverBackgroundColor(hotButtonColor);
        magnitudeBaseMinSpinner.SetMouseOverBackgroundColor(hotButtonColor);
        magnitudeBaseMaxSpinner.SetMouseOverBackgroundColor(hotButtonColor);
        
        // Set spinner ranges
        durationBaseSpinner.SetRange(1, 60);
        chanceBaseSpinner.SetRange(1, 100);
        magnitudeBaseMinSpinner.SetRange(1, 999);
        magnitudeBaseMaxSpinner.SetRange(1, 999);
        
        // Set spinner events
        durationBaseSpinner.OnUpButtonClicked += DurationBaseSpinner_OnUpButton;
        durationBaseSpinner.OnDownButtonClicked += DurationBaseSpinner_OnDownButton;
        chanceBaseSpinner.OnUpButtonClicked += ChanceBaseSpinner_OnUpButton;
        chanceBaseSpinner.OnDownButtonClicked += ChanceBaseSpinner_OnDownButton;
        magnitudeBaseMinSpinner.OnUpButtonClicked += MagnitudeBaseMinSpinner_OnUpButton;
        magnitudeBaseMinSpinner.OnDownButtonClicked += MagnitudeBaseMinSpinner_OnDownButton;
        magnitudeBaseMaxSpinner.OnUpButtonClicked += MagnitudeBaseMaxSpinner_OnUpButton;
        magnitudeBaseMaxSpinner.OnDownButtonClicked += MagnitudeBaseMaxSpinner_OnDownButton;

        durationBaseSpinner.OnValueChanged += DurationBaseSpinner_OnValueChanged;
        chanceBaseSpinner.OnValueChanged += ChanceBaseSpinner_OnValueChanged;
        magnitudeBaseMinSpinner.OnValueChanged += MagnitudeBaseMinSpinner_OnValueChanged;
        magnitudeBaseMaxSpinner.OnValueChanged += MagnitudeBaseMaxSpinner_OnValueChanged;
    }

    protected override void UpdateCosts()
    {
        RaiseSettingsChanged();

        // Get spell cost
        (int goldCost, int spellPointCost) = FormulaHelper.CalculateEffectCosts(EffectEntry);
        goldCostLabel.Text = goldCost.ToString();
        spellCostLabel.Text = spellPointCost.ToString();
    }

    protected override void InitControlState()
    {
        // Must have an effect template set
        if (EffectTemplate == null)
            throw new Exception(noEffectTemplateError);

        // Get description text
        TextFile.Token[] descriptionTokens = EffectTemplate.SpellMakerDescription;
        if (descriptionTokens == null || descriptionTokens.Length == 0)
            throw new Exception(string.Format("DaggerfallEffectSettingsEditorWindow: EffectTemplate {0} does not present any spellmaker description text.", EffectTemplate.Key));
        else
            descriptionLabel.SetText(descriptionTokens);

        // Duration support
        if (EffectTemplate.Properties.SupportDuration)
        {
            durationBaseSpinner.Enabled = true;
        }
        else
        {
            durationBaseSpinner.Enabled = false;
        }

        // Chance support
        if (EffectTemplate.Properties.SupportChance)
        {
            chanceBaseSpinner.Enabled = true;
        }
        else
        {
            chanceBaseSpinner.Enabled = false;
        }

        // Magnitude support
        if (EffectTemplate.Properties.SupportMagnitude)
        {
            magnitudeBaseMinSpinner.Enabled = true;
            magnitudeBaseMaxSpinner.Enabled = true;
        }
        else
        {
            magnitudeBaseMinSpinner.Enabled = false;
            magnitudeBaseMaxSpinner.Enabled = false;
        }
    }

    protected override EffectEntry GetEffectEntry()
    {
        // Must have an effect template set
        if (EffectTemplate == null)
            throw new Exception(noEffectTemplateError);

        // Create settings for effect
        EffectSettings effectSettings = new EffectSettings();
        if (IsSetup)
        {
            // Assign from UI control when setup
            effectSettings.DurationBase = durationBaseSpinner.Value;
            effectSettings.DurationPlus = 0;
            effectSettings.DurationPerLevel = 1;
            effectSettings.ChanceBase = chanceBaseSpinner.Value;
            effectSettings.ChancePlus = 0;
            effectSettings.ChancePerLevel = 1;
            effectSettings.MagnitudeBaseMin = magnitudeBaseMinSpinner.Value;
            effectSettings.MagnitudeBaseMax = magnitudeBaseMaxSpinner.Value;
            effectSettings.MagnitudePlusMin = 0;
            effectSettings.MagnitudePlusMax = 0;
            effectSettings.MagnitudePerLevel = 1;
        }

        // Create entry
        EffectEntry effectEntry = new EffectEntry();
        effectEntry.Key = EffectTemplate.Key;
        effectEntry.Settings = effectSettings;

        return effectEntry;
    }

    protected override void SetEffectEntry(EffectEntry entry)
    {
        if (!IsSetup)
            return;

        // Assign effect template based on entry key
        EffectTemplate = GameManager.Instance.EntityEffectBroker.GetEffectTemplate(entry.Key);
        if (EffectTemplate == null)
            throw new Exception(string.Format("SetEffectEntry() could not find effect key {0}", entry.Key));

        // Assign settings to spinners
        durationBaseSpinner.Value = entry.Settings.DurationBase;
        chanceBaseSpinner.Value = entry.Settings.ChanceBase;
        magnitudeBaseMinSpinner.Value = entry.Settings.MagnitudeBaseMin;
        magnitudeBaseMaxSpinner.Value = entry.Settings.MagnitudeBaseMax;
    }

    protected override void SetSpinners(EffectSettings settings)
    {
        if (!IsSetup)
            return;

        durationBaseSpinner.Value = settings.DurationBase;
        chanceBaseSpinner.Value = settings.ChanceBase;
        magnitudeBaseMinSpinner.Value = settings.MagnitudeBaseMin;
        magnitudeBaseMaxSpinner.Value = settings.MagnitudeBaseMax;
    }

    #endregion

    #region Event Handlers

    protected void DurationBaseSpinner_OnUpButton()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            durationBaseSpinner.Value += 9;
        }
    }

    protected void DurationBaseSpinner_OnDownButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            durationBaseSpinner.Value -= 9;
        }
    }

    protected void ChanceBaseSpinner_OnUpButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            chanceBaseSpinner.Value += 9;
        }
    }

    protected void ChanceBaseSpinner_OnDownButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            chanceBaseSpinner.Value -= 9;
        }
    }

    protected void MagnitudeBaseMinSpinner_OnUpButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            magnitudeBaseMinSpinner.Value += 9;
        }
    }

    protected void MagnitudeBaseMinSpinner_OnDownButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            magnitudeBaseMinSpinner.Value -= 9;
        }
    }

    protected void MagnitudeBaseMaxSpinner_OnUpButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            magnitudeBaseMaxSpinner.Value += 9;
        }
    }

    protected void MagnitudeBaseMaxSpinner_OnDownButton()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            magnitudeBaseMaxSpinner.Value -= 9;
        }
    }

    #endregion
}
