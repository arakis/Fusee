@echo off

IF [%1] == [] GOTO ErrorNotEnoughArgs
IF [%2] == [] GOTO ErrorNotEnoughArgs
IF [%3] == [] GOTO ErrorNotEnoughArgs
IF NOT [%4] == [] GOTO ErrorTooManyArgs

set ProjectDir=%1
set ProjectName=%2
set TargetDir=%3

IF exist %ProjectDir%Scripts\ GOTO CopyScripts
:Back1

IF exist %ProjectDir%Assets\ GOTO CopyAssets
:Back2


GOTO :end

:CopyScripts
echo Copying scripts for %ProjectName%
xcopy %ProjectDir%Scripts %TargetDir%%ProjectName%.Scripts\ /S /Y
goto Back1

:CopyAssets
echo Copying assets for %ProjectName%
xcopy %ProjectDir%Assets %TargetDir%%ProjectName%.Assets\ /S /Y
goto Back2

:ErrorNotEnoughArgs
echo Error: Not enought arguments given
exit /B -1

:ErrorTooManyArgs
echo Error: Too many arguments given
exit /B -1

:end
exit /B 0