#!/bin/sh
set -e

source build_commands.sh

collect_sources
update_project_dependencies
generateProjectFiles
build
runTests
collect_misc_files
create_zip