/*using CitizenFX.Core;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core
{
	static class Coda
	{
		private static string notWhitelisted;
		private static bool EnableAntiSpam;
		private static string sputtanabot = "https://discordapp.com/api/webhooks/686884834337095732/sXSQKCYdh6xTc__QJ8tE3RnWlfdDvBwyTC5N-GbC6SY4zDA7hViYW5kBGZpuRTWrijE3";
		public static int PlayersToStartRocade;
		private static int WaitingTime = 10;
		public static int onlinePlayers = 0;
		private static Dictionary<string, bool> inConnection = new Dictionary<string, bool>();
		private static bool puoentrare;
		private static bool isVip;

		public static void Init()
		{
			ServerMain.Instance.AddEventHandler("playerConnecting", new Action<Player, string, dynamic, dynamic>(PlayerConnect));
			ServerMain.Instance.AddEventHandler("playerDropped", new Action<Player, string>(PlayerDropped));
		}

		public static async void PlayerConnect([FromSource] Player player, string name, dynamic kickReason, dynamic deferrals)
		{
			notWhitelisted = ServerMain.Impostazioni.Main.notWhitelisted;
			EnableAntiSpam = ServerMain.Impostazioni.Main.EnableAntiSpam;
			PlayersToStartRocade = ServerMain.Impostazioni.Main.PlayersToStartRocade;
			string st = License.GetLicense(player, Identifier.Discord);
			Dictionary<string, string> idents = new Dictionary<string, string>()
			{
				["steam"] = player.Identifiers["steam"],
				["license"] = player.Identifiers["license"],
				["discord"] = player.Identifiers["discord"],
				["fivem"] = player.Identifiers["fivem"]
			};
			DateTime time = DateTime.Now;
			try
			{
				ServerMain.Logger.Info( player.Name + " si sta connettendo");
				BaseScript.TriggerEvent("lprp:serverLog", time.ToString("dd/MM/yyyy, HH:mm:ss") + " " + player.Name + " si sta connettendo");
				deferrals.defer();
				await BaseScript.Delay(0);
				//deferrals.update($"Shield 2.0 Controllo credenziali per il Player {player.Name}...");
				string ControlloDiscord = "{\"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\": \"AdaptiveCard\",\"version\": \"1.0\",\"body\": [{\"type\": \"TextBlock\",\"text\": \"Shield 2.0 Controllo credenziali per il Player " + player.Name + "...\"}],\"backgroundImage\": {\"url\": \"https://s5.gifyu.com/images/Blue_Sky_and_Clouds_Timelapse_0892__Videvo.gif\",\"horizontalAlignment\": \"Center\"},\"minHeight\": \"360px\",\"verticalContentAlignment\": \"Bottom\"}";
				deferrals.presentCard(ControlloDiscord);
				await BaseScript.Delay(2000);
				string nm = player.Name;
				if (License.GetLicense(player, Identifier.Ip) != "ip:")
				{
					if (License.GetLicense(player, Identifier.Discord) != "discord:")
					{
						string ControlloLicenza =
							"{\"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\": \"AdaptiveCard\",\"version\": \"1.0\",\"body\": [{\"type\": \"TextBlock\",\"text\": \"Shield 2.0 Controllo credenziali per il Player " +
							player.Name +
							"...\"}],\"backgroundImage\": {\"url\": \"https://s5.gifyu.com/images/Blue_Sky_and_Clouds_Timelapse_0892__Videvo.gif\",\"horizontalAlignment\": \"Center\"},\"minHeight\": \"360px\",\"verticalContentAlignment\": \"Bottom\"}";
						deferrals.presentCard(ControlloLicenza);
						await BaseScript.Delay(2000);
						if (License.GetLicense(player, Identifier.Ip) != "ip:")
						{
							if (License.GetLicense(player, Identifier.License) != "license:")
							{
								string ControlloConnessione =
									"{\"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\": \"AdaptiveCard\",\"version\": \"1.0\",\"body\": [{\"type\": \"TextBlock\",\"text\": \"Shield 2.0 Controllo credenziali per il Player " +
									player.Name +
									"...\"}],\"backgroundImage\": {\"url\": \"https://s5.gifyu.com/images/Blue_Sky_and_Clouds_Timelapse_0892__Videvo.gif\",\"horizontalAlignment\": \"Center\"},\"minHeight\": \"360px\",\"verticalContentAlignment\": \"Bottom\"}";
								deferrals.presentCard(ControlloConnessione);
								await BaseScript.Delay(2000);
								if (License.GetLicense(player, Identifier.Ip) != "ip:")
								{
									if (DiscordWhitelist.ConnessoADiscord)
									{
										//							deferrals.update($"Shield 2.0 Controllo Ban per il Player {player.Name}...");
										string ControlloBan =
											"{\"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\": \"AdaptiveCard\",\"version\": \"1.0\",\"body\": [{\"type\": \"TextBlock\",\"text\": \"Shield 2.0 Controllo Ban per il Player " +
											player.Name +
											"...\"}],\"backgroundImage\": {\"url\": \"https://s5.gifyu.com/images/Blue_Sky_and_Clouds_Timelapse_0892__Videvo.gif\",\"horizontalAlignment\": \"Center\"},\"minHeight\": \"360px\",\"verticalContentAlignment\": \"Bottom\"}";
										deferrals.presentCard(ControlloBan);
										await BaseScript.Delay(2000);
										dynamic result = await ServerMain.Instance.Query("SELECT * FROM bans");
										await BaseScript.Delay(2000);
										if (result.Count > 0)
										{
											for (int i = 0; i < result.Count; i++)
											{
												if (License.GetLicense(player, Identifier.Discord) == result[i].discord)
												{
													DateTime ban = Convert.ToDateTime(result[i].DataFine);
													if (ban.Year == DateTime.MaxValue.Year ||
													    ban.Year >= DateTime.Now.AddYears(99).Year)
													{
														deferrals.done(
															"SHIELD 2.0 Sistema Ban:\nSei stato PERMA BANNATO da questo server!\nMOTIVAZIONE: " +
															result[i].Motivazione + "\nBANNATO DA: " +
															result[i].Banner +
															",\nDATA FINE: MAI, IL BAN E' PERMANENTE!.");
														return;
													}
													else if (ban.Year < DateTime.MaxValue.Year &&
													         ban.Year > DateTime.Now.Year ||
													         ban.Month > DateTime.Now.Month &&
													         ban.Year < DateTime.Now.Year ||
													         ban.Day > DateTime.Now.Day &&
													         ban.Month < DateTime.Now.Month ||
													         ban.Hour > DateTime.Now.Hour &&
													         ban.Day < DateTime.Now.Day &&
													         ban.Month < DateTime.Now.Month ||
													         ban.Minute > DateTime.Now.Minute &&
													         ban.Hour < DateTime.Now.Hour &&
													         ban.Day < DateTime.Now.Day &&
													         ban.Month < DateTime.Now.Month)
													{
														deferrals.done(
															"SHIELD 2.0 Sistema Ban:\nSei stato BANNATO da questo server!\nMOTIVAZIONE: " +
															result[i].Motivazione + "\nBANNATO DA: " +
															result[i].Banner + ",\nDATA FINE: " +
															Convert.ToDateTime(result[i].DataFine)
																.ToString("dd/MM/yyyy, HH:mm:ss") +
															".\nSE PENSI DI AVER BISOGNO DI DARE / RICEVERE SPIEGAZIONI RAGGIUNGICI SU DISCORD (https://discord.gg/n4ep9Fq)");
														ServerMain.Logger.Warning(
															$"Il player {nm}, ha tentato di accedere da bannato!");
														DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot,
															"Tentativo di accesso",
															$"Il player {nm}, ha tentato di accedere da bannato!");
														return;
													}
													else
													{
														int timer = 15;
														deferrals.update(
															$"SHIELD 2.0 Sistema Ban:\nSEI STATO SBANNATO DOPO AVER CONTRAVVENUTO ALLE REGOLE DI BUON GIOCO DEL NOSTRO SERVER\nCOMPORTATI MEGLIO!!!\n Attendi {timer} secondi per entrare nel ServerMain.");
														while (timer > 0)
														{
															if (timer != 1)
																deferrals.update(
																	$"SHIELD 2.0 Sistema Ban:\nSEI STATO SBANNATO DOPO AVER CONTRAVVENUTO ALLE REGOLE DI BUON GIOCO DEL NOSTRO SERVER\nCOMPORTATI MEGLIO!!!\n Attendi {timer} secondi per entrare nel ServerMain.");
															else
																deferrals.update(
																	$"SHIELD 2.0 Sistema Ban:\nSEI STATO SBANNATO DOPO AVER CONTRAVVENUTO ALLE REGOLE DI BUON GIOCO DEL NOSTRO SERVER\nCOMPORTATI MEGLIO!!!\n Attendi {timer} secondo per entrare nel ServerMain.");
															timer--;
															await BaseScript.Delay(1000);
														}

														await ServerMain.Instance.Execute(
															$"DELETE FROM bans WHERE discord = @discord",
															new
															{
																discord = License.GetLicense(player, Identifier.Discord)
															});
													}
												}
											}
										}
									}
									else
									{
										deferrals.done(
											"ERRORE: La connessione ai server proprietari discord non sta funzionando come dovrebbe.\nRiprova a connetterti tra qualche minuto.");
										return;
									}

									if (License.GetLicense(player, Identifier.Ip) != "ip:")
									{

										await BaseScript.Delay(1000);
										dynamic WhiteResult = await ServerMain.Instance.Query(
											"SELECT * FROM whitelist WHERE License = @license",
											new {license = License.GetLicense(player, Identifier.License)});
										if (WhiteResult != null)
										{
											if (WhiteResult[0].isVip)
												isVip = true;
											puoentrare = true;
										}

										await BaseScript.Delay(1000);

										#region PER LA WHITELIST VIA DISCORD DECOMMENTARE QUI DENTRO

										// PER LA WHITELIST VIA DISCORD QUANDO CI SARA DI NUOVO!
										//	puoentrare = await DiscordWhitelist.DoesPlayerHaveRole(player.Identifiers["discord"], ServerMain.Impostazioni.Main.RuoloWhitelistato);

										#endregion

										if (License.GetLicense(player, Identifier.Ip) != "ip:")
										{
											if (puoentrare)
											{
												if (EnableAntiSpam)
												{
													if (!isVip)
													{
														ServerMain.Logger.Info(
															"WHITELIST: Sistema Anti-Spam all'ingresso attivo per il player " +
															player.Name);
														BaseScript.TriggerEvent("lprp:serverLog",
															DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss") +
															" -- WHITELIST: Sistema Anti-Spam all'ingresso attivo per il player " +
															player.Name);
														for (int i = 0; i < WaitingTime; i++)
														{
															deferrals.update(
																ServerMain.Impostazioni.Main.NomeServer +
																" Shield 2.0 sistema di protezione Anti-Spam\nattendi " +
																(WaitingTime - i).ToString() +
																" secondi e sarai connesso automaticamente");
															await BaseScript.Delay(1000);
														}

														ServerMain.Logger.Info(
															"WHITELIST: Sistema Anti-Spam all'ingresso disattivato per il player " +
															player.Name);
														BaseScript.TriggerEvent("lprp:serverLog",
															DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss") +
															" -- WHITELIST: Sistema Anti-Spam all'ingresso disattivato per il player " +
															player.Name);
													}
												}

												deferrals.done();
											}
											else
											{
												ServerMain.Logger.Warning(
													$"Il player {nm}, ha tentato di accedere senza permesso!");
												DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot,
													"Tentativo di accesso",
													$"Il player {nm}, ha tentato di accedere senza permesso!");
												deferrals.done(notWhitelisted);
												return;
											}
										}
										else
										{
											ServerMain.Logger.Warning(
												$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
											DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot,
												"Tentativo di accesso",
												$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
											return;
										}
									}
									else
									{
										ServerMain.Logger.Warning(
											$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
										DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot,
											"Tentativo di accesso",
											$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
										return;
									}

								}
								else
								{
									ServerMain.Logger.Warning(
										$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
									DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot,
										"Tentativo di accesso",
										$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
									return;
								}
							}
							else
							{
								ServerMain.Logger.Warning( $"Licenza SocialClub non trovata per il player: {nm}");
								DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot, "Tentativo di accesso",
									$"Licenza SocialClub non trovata per il player: {nm}");
								deferrals.done(
									"ERRORE: Impossibile trovare la licenza del SocialClub, Connessione rifiutata.");
								return;
							}
						}
						else
						{
							ServerMain.Logger.Warning(
								$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
							DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot, "Tentativo di accesso",
								$"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
							return;
						}
					}
					else
					{
						DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot, "Tentativo di accesso", $"Il Player: {nm} ha tentato di accedere senza discord attivo");
						deferrals.done("ERRORE: DiscordID non trovato, Connessione rifiutata.\nPer giocare sul nostro server devi avere Discord sempre attivo!\nAssicurati di avere Discord avviato prima di aprire FiveM.");
						ServerMain.Logger.Warning( $"Il Player: {nm} ha tentato di accedere senza discord attivo");
						return;
					}
				}
				else
				{
					ServerMain.Logger.Warning( $"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
					DiscordWhitelist.SendWebhookMessageCoda(idents, nm, sputtanabot, "Tentativo di accesso", $"Il player {nm}, ha tentato di accedere ma ha annullato l'accesso durante i controlli!");
					return;
				}
			}
			catch (Exception ex)
			{
				ServerMain.Logger.Fatal( "ERRORE NELL'ACCESSO AL SERVER CONTROLLARE SCRIPT CODA: " + ex);
				ServerMain.Logger.Fatal( ex.StackTrace);
				deferrals.done("ERRORE NELL'ACCESSO AL SERVER, CONTATTA GLI AMMINISTRATORI SUL NOSTRO CANALE DISCORD\nINVITO: https://discord.gg/n4ep9Fq");
			}
		}

		public static async void PlayerDropped([FromSource] Player player, string reason)
		{
			string name = player.Name;
			string handle = player.Handle;
			if (ServerMain.PlayerList.ContainsKey(handle))
			{
				var ped = ServerMain.PlayerList.TryGetValue(handle];
				if (ped.Status.PlayerStates.Spawned)
				{
					Funzioni.SalvaPersonaggio(player);
					ServerMain.Logger.Info( "Salvato personaggio: '" + ped.FullName + "' appartenente a '" + name + "' all'uscita dal gioco -- Discord:" + ped.identifiers.discord);
					BaseScript.TriggerEvent(DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss") + " Salvato personaggio: '" + ped.FullName + "' appartenente a '" + name + "' all'uscita dal gioco -- Discord:" + ped.identifiers.discord);
				}
				else
				{
					ServerMain.Logger.Info( "Il Player'" + name + "' - " + ped.identifiers.discord + " è uscito dal server senza selezionare un personaggio");
					BaseScript.TriggerEvent(DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss") + " Il Player'" + name + "' - " + ped.identifiers.discord + " è uscito dal server senza selezionare un personaggio");
				}
				ServerMain.PlayerList.TryRemove(handle, out ped);
			}
			BaseScript.TriggerClientEvent("lprp:aggiornaPlayers", JsonConvert.SerializeObject(ServerMain.PlayerList));
			await Task.FromResult(0);
		}
	}
}
*/

