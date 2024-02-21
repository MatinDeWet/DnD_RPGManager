------------------------------------------ Add-Migration ------------------------------------------ 
EntityFrameworkCore\Add-Migration xxx -Context SpellContext -Project RPGManager.Spell.Persistence -StartupProject RPGManager.Spell.API -verbose

------------------------------------------ Remove-Migration ------------------------------------------ 
EntityFrameworkCore\Remove-Migration -Context SpellContext -Project RPGManager.Spell.Persistence -StartupProject RPGManager.Spell.API -verbose

------------------------------------------ Update-Database ------------------------------------------ 
EntityFrameworkCore\Update-Database -Context SpellContext -Project RPGManager.Spell.Persistence -StartupProject RPGManager.Spell.API -verbose