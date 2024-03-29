﻿
# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

$namePrefix = 'my'
$vnetNamespace = 'myVnet/'
$rgLocation = 'WestUS2'

Arm {
    $PSDefaultParameterValues['Resource:Location'] = $rgLocation

    Resource "${vnetNamespace}${namePrefix}-subnet" -Namespace Microsoft.Network -ApiVersion 2019-11-01 -Type virtualNetworks/subnets {
        properties {
            addressPrefix 10.0.0.0/24
        }
    }

    'pip1','pip2' | ForEach-Object {
        Resource "$namePrefix-$_" -Namespace Microsoft.Network -ApiVersion 2019-11-01 -Type publicIPAddresses {
            properties {
                publicIPAllocationMethod Dynamic
            }
        }
    }

    Resource "$namePrefix-nic"  -Namespace Microsoft.Network -ApiVersion 2019-11-01 -Type networkInterfaces {
        properties {
            ipConfigurations {
                name 'myConfig'
                properties {
                    privateIPAllocationMethod Dynamic
                    subnet {
                        id (resourceId 'Microsoft.Network/virtualNetworks/subnets' "$namePrefix-nic-subnet")
                    }
                }
            }
        }
    }

    Output 'nicResourceId' -Type 'string' -Value (resourceId 'Microsoft.Network/networkInterfaces' "$namePrefix-nic")
}
