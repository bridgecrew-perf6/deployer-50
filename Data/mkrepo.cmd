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

mkdir releases
mkdir releases\IG
mkdir releases\IG\head
mkdir releases\IG\candidate
mkdir releases\IG\final

mkdir installs
mkdir installs\CZ
mkdir installs\CZ\Brno
mkdir installs\CZ\Brno\Evn1
mkdir installs\CZ\Brno\Evn1\trunk
mkdir installs\CZ\Brno\Evn1\trunk\IG
mkdir installs\CZ\Brno\Evn1\trunk\IG\Bin
mkdir installs\CZ\Brno\Evn1\trunk\IG\Config
mkdir installs\CZ\Brno\Evn1\trunk\IG\Data
mkdir installs\CZ\Brno\Evn1\trunk\Spec
mkdir installs\CZ\Brno\Evn1\trunk\Spec\IG
echo --- > installs\CZ\Brno\Evn1\trunk\Spec\IG\custom.lua

svn add *
svn propset svn:externals -F ..\externals-IG-head.txt releases/IG/head
svn commit -m "initial"

popd
