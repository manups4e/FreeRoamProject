fx_version 'cerulean'
game 'gta5'

loadscreen_manual_shutdown 'yes'
clr_experimental_2021_12_31_use_sync_context 'on'
--fxevents_debug_mode '1'

files {
	--"html/**/*",
    'Client/Newtonsoft.Json.dll',
    'Client/ScaleformUI.dll',
    'Client/FxEvents.Client.dll',
}

client_scripts{
    "Client/pedComponentExtensions.lua",
    "Client/FreeRoamProject.Client.net.dll"
}

server_script "Server/FreeRoamProject.Server.net.dll"

--ui_page "html/index.html"
--loadscreen 'html/loadingscreen/loading.html'