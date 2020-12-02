setlocal EnableExtensions
rmdir /s/q sandbox
::if not errorlevel 1 goto :EOF
attrib -r repo\*.* /s
rmdir /s/ q repo
::if not errorlevel 1 goto :EOF

svnadmin create repo

mkdir sandbox

svn checkout file:///%~dp0repo sandbox

pushd sandbox

mkdir shared
mkdir shared\IG
mkdir shared\IG\Bin\All\trunk
mkdir shared\IG\Bin\All\tags
mkdir shared\IG\Bin\All\branches
mkdir shared\IG\Bin\All\trunk\sub1
echo 0 > shared\IG\Bin\All\trunk\VersionStamp.txt
echo 0 > shared\IG\Bin\All\trunk\sub1\file.txt
mkdir shared\IG\Bin\Dirigent\trunk
mkdir shared\IG\Config
mkdir shared\IG\Config\Base
mkdir shared\IG\Config\Devel
mkdir shared\IG\Config\Test
mkdir shared\IG\Config\Base\tags
mkdir shared\IG\Config\Base\trunk
mkdir shared\IG\Config\Test\CZ
mkdir shared\IG\Config\Test\CZ\Brno
mkdir shared\IG\Config\Test\CZ\Brno\DemoRoom1
mkdir shared\IG\Config\Test\CZ\Brno\DemoRoom1\trunk

mkdir shared\UI
mkdir shared\UI\Bin\All\trunk
mkdir shared\UI\Bin\All\tags
mkdir shared\UI\Bin\All\branches
mkdir shared\UI\Bin\All\trunk\sub1
echo 0 > shared\UI\Bin\All\trunk\VersionStamp.txt


mkdir release
mkdir release\IG
mkdir release\IG\head
mkdir release\IG\head\Master
mkdir release\IG\candidate
mkdir release\IG\final

mkdir release
mkdir release\UI
mkdir release\UI\head
mkdir release\UI\head\Master
mkdir release\UI\integration
::mkdir release\UI\integration\2.0.7

mkdir install
mkdir install\CZ
mkdir install\CZ\Brno
mkdir install\CZ\Brno\DemoRoom
mkdir install\CZ\Brno\DemoRoom\trunk
mkdir install\CZ\Brno\DemoRoom\trunk\Spec
mkdir install\CZ\Brno\DemoRoom\trunk\Spec\IG
echo --- > install\CZ\Brno\DemoRoom\trunk\Spec\IG\custom.lua


svn add *
svn propset svn:externals -F ..\externals-IG-head.txt release/IG/head/Master
svn propset svn:externals -F ..\externals-UI-head.txt release/UI/head/Master
svn propset svn:externals -F ..\externals-Install.txt install/CZ/Brno/DemoRoom/trunk
svn commit -m "initial"

popd
