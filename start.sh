#! /bin/bash

RUNNANE="dotnet run"
nohup $RUNNANE &
runCheck=`ps -ef | grep -v grep | grep "${RUNNAME}" | wc -l`
echo "running process count = [${runCheck}]"