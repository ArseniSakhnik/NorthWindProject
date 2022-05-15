import {ServiceTypeEnum} from "@/enums/Enums";

export function getServiceName(serviceTypeId: ServiceTypeEnum): string {
    switch (serviceTypeId) {
        case ServiceTypeEnum.Assenizator:
            return 'ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА';
        case ServiceTypeEnum.KGO:
            return 'ОТКАЧКА ЖИДКИХ БЫТОВЫХ ОТХОДОВ';
        case ServiceTypeEnum.WaterCleaning:
            return 'ПОЛИВ И ОЧИСТКА ТЕРРИТОРИЙ';
    }
    
    return '';
}