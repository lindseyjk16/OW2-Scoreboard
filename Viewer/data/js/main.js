//------------------------------------------------------------------------------
// main.js
//------------------------------------------------------------------------------

	var xhr = new XMLHttpRequest();
	var ScoreFile;
	var OldScoreFile;
	var ConfigFile;
	var OldConfigFile;
	var Elements;
	var IsPlaying = false;
	var ScoreFilePath = "./score.json";
	var ConfigFilePath = "./config.json";

	const NUMBER_OF_DIVISIONS = 7;
	const NUMBER_OF_TIERS = 5;
	const compareIgnoreCase = (string1, string2) => string1.toLowerCase() === string2.toLowerCase();

	//--------------------------------------------------------------------------
	// Initialize
	//--------------------------------------------------------------------------
	function Initialize()
	{
		// First hide all boards
		$('.Board').hide();

		Elements = {
			Wins1:	$('#ScoreBoard .Score .Win'),
			Wins2:	$('#Scores .Score .Win'),
			Loses1: $('#ScoreBoard .Score .Lose'),
			Loses2:	$('#Scores .Score .Lose'),
			Draws1:	$('#ScoreBoard .Score .Draw'),
			Draws2:	$('#Scores .Score .Draw'),
		}

		xhr.overrideMimeType('application/json');

		LoadScore();
		setInterval("LoadScore()", 1000);

		LoadConfig()
		setInterval("LoadConfig()", 5000);

		setInterval("FadeStartingRateRole()", 5000);
	}

	//--------------------------------------------------------------------------
	// LoadScore
	//--------------------------------------------------------------------------
	function LoadScore() {
		console.log("LoadScore");

		if( !IsPlaying )
		{
			xhr.open('GET', ScoreFilePath+"?dummy="+Date.now(), true);
			xhr.send();
			xhr.onreadystatechange = function(){
				if (xhr.readyState === 4) {
					// Remember previous state
					if( ScoreFile != undefined )
					{
						OldScoreFile = ScoreFile;
					}
					// Parse the loaded Json
					ScoreFile = JSON.parse(xhr.responseText);
					// Set OldScoreFile and update scoreboard
					if( OldScoreFile == undefined )
					{
						OldScoreFile = ScoreFile;
						SetScore();
					}
					else
					{
						ScoreScrutiny();
					}
				}
			}		
		}
	}

	//--------------------------------------------------------------------------
	// SetScore
	//--------------------------------------------------------------------------
	function SetScore() {
		console.log("SetScore");

		Elements.Wins1.text(ScoreFile.Wins);
		Elements.Wins2.text(ScoreFile.Wins);
		Elements.Loses1.text(ScoreFile.Loses);
		Elements.Loses2.text(ScoreFile.Loses);
		Elements.Draws1.text(ScoreFile.Draws);
		Elements.Draws2.text(ScoreFile.Draws);

		var startingRate = $('#ScoreBoard > .StartingRate');
		var spacer = $('#ScoreBoard > .Spacer');
		if( ScoreFile.IsOpenQueueMode || ScoreFile.IsTankRankEnabled || ScoreFile.IsDamageRankEnabled || ScoreFile.IsSupportRankEnabled )
		{
			startingRate.show();
			spacer.show();
		}
		else
		{
			startingRate.hide();
			spacer.hide();
		}

		var activeStartingRateRole = null;
		if( ScoreFile.IsOpenQueueMode || ScoreFile.IsTankRankEnabled )
		{
			activeStartingRateRole = "Tank";
		}
		else if( ScoreFile.IsDamageRankEnabled )
		{
			activeStartingRateRole = "Damage";
		}
		else if( ScoreFile.IsSupportRankEnabled )
		{
			activeStartingRateRole = "Support";
		}

		var startingRates = {};
		var tankRoleIcon = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.Tank > .RoleIcon');
		if( ScoreFile.IsOpenQueueMode )
		{
			tankRoleIcon.hide();
		}
		else
		{
			tankRoleIcon.show();
		}
		// Only use the tank node if in open queue mode
		startingRates["Tank"] = {
			RankDivision: ScoreFile.TankRankDivision,
			RankTier: ScoreFile.TankRankTier,
			IsInPlacement: ScoreFile.IsTankInPlacement,
			IsShow: (ScoreFile.IsOpenQueueMode || ScoreFile.IsTankRankEnabled),
			Opacity: (activeStartingRateRole == "Tank" || ScoreFile.IsOpenQueueMode) ? '1' : '0'
		};
		startingRates["Damage"] = {
			RankDivision: ScoreFile.DamageRankDivision,
			RankTier: ScoreFile.DamageRankTier,
			IsInPlacement: ScoreFile.IsDamageInPlacement,
			IsShow: (!ScoreFile.IsOpenQueueMode && ScoreFile.IsDamageRankEnabled),
			Opacity: activeStartingRateRole == "Damage" ? '1' : '0'
		};
		startingRates["Support"] = {
			RankDivision: ScoreFile.SupportRankDivision,
			RankTier: ScoreFile.SupportRankTier,
			IsInPlacement: ScoreFile.IsSupportInPlacement,
			IsShow: (!ScoreFile.IsOpenQueueMode && ScoreFile.IsSupportRankEnabled),
			Opacity: activeStartingRateRole == "Support" ? '1' : '0'
		};

		Object.keys(startingRates).forEach(function(key)
		{
			var startingRate = startingRates[key];
			var targetRole = key;
			if (startingRate.IsInPlacement)
			{
				SetStartingRate("PLACEMENT", 5, targetRole, startingRate.IsShow, startingRate.Opacity);
			}
			else
			{
				SetStartingRate(startingRate.RankDivision, startingRate.RankTier, targetRole, startingRate.IsShow, startingRate.Opacity);
			}
		});

		UpdateRateContainerSize();
	}

	//--------------------------------------------------------------------------
	// LoadConfig
	//--------------------------------------------------------------------------
	function LoadConfig()
	{
		console.log("LoadConfig");

		xhr.open('GET', ConfigFilePath+"?dummy="+Date.now(), true);
		xhr.send();
		xhr.onreadystatechange = function(){
			if (xhr.readyState === 4) {
				// Remember previous stte
				if( ConfigFile != undefined )
				{
					OldConfigFile = ConfigFile;
				}
				// Parse loaded Json
				ConfigFile = JSON.parse(xhr.responseText);
				// Set OldConfigFile and configure
				if( OldConfigFile == undefined )
				{
					OldConfigFile = ConfigFile;
					SetConfig();
				}
				else
				{
					ConfigScrutiny();
				}
			}
		}		
	}

	//--------------------------------------------------------------------------
	// SetConfig
	//--------------------------------------------------------------------------
	function SetConfig()
	{
		console.log("SetConfig");

		// Set name
		$('#Wins > .Name, #Loses > .Name').text(ConfigFile.Name);

		// Set logo image
		$('#Wins > .Logo > img, #Loses > .Logo > img').attr('src', ConfigFile.LogoImageFilePath+"?dummy="+Date.now());

		// Set primary color
		$('#Wins, #Loses, #Draw').css('background', ConfigFile.MainColorHtml);

		// Set secondary color
		$('#Transition, #EdgeLeft, #EdgeRight').css('background', ConfigFile.SubColorHtml);

		// Set font color
		$('#Wins, #Loses, #Draw').css('color', ConfigFile.FontColorHtml);

		// Set scoreboard size and position
		var Size = ConfigFile.ScoreBoardSize/100.0;
		var Margin = 4*Size;//vh
		$('#ScoreBoard').css('transform', 'scale('+Size+')')
		$('#ScoreBoard').css('bottom', '');
		$('#ScoreBoard').css('top', '');
		$('#ScoreBoard').css(ConfigFile.ScoreBoardPosition, Margin+'vh');
	}

	//--------------------------------------------------------------------------	
	// ScoreScrutiny
	//--------------------------------------------------------------------------
	function ScoreScrutiny()
	{
		console.log("ScoreScrutiny");

		var UpdateType = undefined;

		if( ScoreFile.Wins != OldScoreFile.Wins )
		{
			if( UpdateType == undefined && ScoreFile.Wins > OldScoreFile.Wins )
			{
				UpdateType = "Win";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.Loses != OldScoreFile.Loses )
		{
			if( UpdateType == undefined && ScoreFile.Loses > OldScoreFile.Loses  )
			{
				UpdateType = "Lose";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.Draws != OldScoreFile.Draws )
		{
			if( UpdateType == undefined && ScoreFile.Draws > OldScoreFile.Draws )
			{
				UpdateType = "Draw";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.IsTankRankEnabled != OldScoreFile.IsTankRankEnabled
		||	ScoreFile.IsDamageRankEnabled != OldScoreFile.IsDamageRankEnabled
		||	ScoreFile.IsSupportRankEnabled != OldScoreFile.IsSupportRankEnabled )
		{
			UpdateType = "General";
		}
		if (ScoreFile.TankRankDivision != OldScoreFile.TankRankDivision
		|| ScoreFile.DamageRankDivision != OldScoreFile.DamageRankDivision
		|| ScoreFile.SupportRankDivision != OldScoreFile.SupportRankDivision)
		{
			UpdateType = "General";
		}
		if( ScoreFile.TankRankTier != OldScoreFile.TankRankTier
		||	ScoreFile.DamageRankTier != OldScoreFile.DamageRankTier
		||	ScoreFile.SupportRankTier != OldScoreFile.SupportRankTier )
		{
			UpdateType = "General";
		}
		if( ScoreFile.IsTankInPlacement != OldScoreFile.IsTankInPlacement
		||	ScoreFile.IsDamageInPlacement != OldScoreFile.IsDamageInPlacement
		||	ScoreFile.IsSupportInPlacement != OldScoreFile.IsSupportInPlacement )
		{
			UpdateType = "General";
		}
		if( ScoreFile.IsOpenQueueMode != OldScoreFile.IsOpenQueueMode )
		{
			UpdateType = "General";
		}
		if( !ConfigFile.EnableProduction && UpdateType != undefined )
		{
			UpdateType = "General";
		}

		switch (UpdateType) {
			case "Win":
				Victory();
				break;
			case "Lose":
				Defeat();
				break;
			case "Draw":
				Draw();
				break;
			case "General":
				UpdateScoreBoard();
				break;
		}
	}

	//--------------------------------------------------------------------------
	// ConfigScrutiny
	//--------------------------------------------------------------------------
	function ConfigScrutiny()
	{
		console.log("ConfigScrutiny");

		if( ConfigFile.TimeStamp != OldConfigFile.TimeStamp )
		{
			SetConfig();
		}
	}

	//--------------------------------------------------------------------------
	// Victory
	//--------------------------------------------------------------------------
	function Victory()
	{
		IsPlaying = true;

		$.playSound("./data/wav/wins.wav", ConfigFile.SoundVolume);
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Wins').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Wins').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// Defeat
	//--------------------------------------------------------------------------
	function Defeat()
	{
		IsPlaying = true;

		$.playSound("./data/wav/loses.wav", ConfigFile.SoundVolume)
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Loses').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Loses').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// Draw
	//--------------------------------------------------------------------------
	function Draw()
	{
		IsPlaying = true;

		$.playSound("./data/wav/draw.wav", ConfigFile.SoundVolume)
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Draw').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Draw').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// SetStartingRate
	//--------------------------------------------------------------------------
	function SetStartingRate(division, tier, role, isShown, opacity) {
		var targetRole = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role);
		targetRole.animate({ 'opacity': opacity }, 0);
		if (isShown)
		{
			targetRole.show();
		}
		else
		{
			targetRole.hide();
		}

		$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .sr').text(tier);
		$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division').hide();

		if (compareIgnoreCase(division, "PLACEMENT"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .sr').text("In Placement");
		}
		else if (compareIgnoreCase(division, "BRONZE"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Bronze').show();
		}
		else if (compareIgnoreCase(division, "SILVER"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Silver').show();
		}
		else if (compareIgnoreCase(division, "GOLD"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Gold').show();
		}
		else if (compareIgnoreCase(division, "PLATINUM"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Platinum').show();
		}
		else if (compareIgnoreCase(division, "DIAMOND"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Diamond').show();
		}
		else if (compareIgnoreCase(division, "MASTER"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Master').show();
		}
		else if (compareIgnoreCase(division, "GRANDMASTER"))
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .Division.Grandmaster').show();
		}
		else
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.' + role + ' > .SkillRate > .sr').text("");
        }
	}

	//--------------------------------------------------------------------------
	// UpdateRateContainerSize
	//--------------------------------------------------------------------------
	function UpdateRateContainerSize()
	{
		var rateContainer = $('#ScoreBoard > .StartingRate > .RateContainer');
		var roleElements = rateContainer.children('.Role');

		// Restore width to auto
		roleElements.each(function(index, element)
		{
			$(element).css('width', 'auto');
		});

		if( ScoreFile.IsOpenQueueMode )
		{
			var tankElement = rateContainer.children('.Role.Tank');
			var newContainerSize = tankElement.outerWidth();
			rateContainer.outerWidth(newContainerSize);
		}
		else
		{
			// Get largest element
			var biggestElement = null;
			roleElements.each(function(index, element)
			{
				if( biggestElement == null || $(element).outerWidth() > $(biggestElement).outerWidth() )
				{
					biggestElement = element;
				}
			});

			// Fit all elements to the largest element
			var newContainerSize = $(biggestElement).outerWidth();
			rateContainer.outerWidth(newContainerSize);
			roleElements.each(function(index, element)
			{
				$(element).outerWidth(newContainerSize);
			});
		}
	}

	//--------------------------------------------------------------------------
	// UpdateScoreBoard
	//--------------------------------------------------------------------------
	function UpdateScoreBoard()
	{
		$('#ScoreBoard')
			.animate({'opacity': '0'}, 300, function(){ SetScore(); })
			.animate({'opacity': '1'}, 300);
	}

	//--------------------------------------------------------------------------
	// FadeStartingRateRole
	//--------------------------------------------------------------------------
	function FadeStartingRateRole()
	{
		if( ScoreFile.IsOpenQueueMode )
		{
			return;
		}

		var fadeTable = [];
		if( ScoreFile.IsTankRankEnabled ){ fadeTable.push("Tank"); }
		if( ScoreFile.IsDamageRankEnabled ){ fadeTable.push("Damage"); }
		if( ScoreFile.IsSupportRankEnabled ){ fadeTable.push("Support"); }
		if( fadeTable.length <= 1 )
		{
			/*
			var role = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+fadeTable[0]);
			role.animate({'opacity': '1'}, 1000);
			*/
			return;
		}

		var roles = $('#ScoreBoard > .StartingRate > .RateContainer > .Role');
		var activeElement = null;
		var nextElement = null;
		roles.each(function(index, element)
		{
			if( $(element).css('opacity') == '1' )
			{
				activeElement = element;
				for( var i = index+1; true; i++ )
				{
					if( i == index )
					{
						break;
					}
					if( i >= roles.length )
					{
						i = 0;
					}
					var role = roles[i];
					var roleName = $(role).data('role');
					if( fadeTable.includes(roleName) )
					{
						nextElement = role;
						$(activeElement).animate({'opacity': '0'}, 1000);
						$(nextElement).animate({'opacity': '1'}, 1000);
						return false;
					}
				}
			}
		});
	}
	
	//--------------------------------------------------------------------------
	// Sleep
	//--------------------------------------------------------------------------
	function Sleep(ms)
	{
		// Create a jQuery Deferred
		var objDef = new $.Deferred;
	
		setTimeout(function () {
			// After ms milliseconds, resolves and complete the promise
			objDef.resolve(ms);
		}, ms);

		return objDef.promise();
	};