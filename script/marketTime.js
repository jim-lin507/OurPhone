 jQuery.noConflict();
        jQuery(function ($) {
            var $birthYear = $('.gbiaps_birthday_year');
            //$('#ProductNum').valueOf('12');
            var year = new Date().getFullYear();
            $('<option value="' + year + '" selected="selected" >' + year + '</option>').appendTo($birthYear);
            for (var i = 1; i <= 100; i++) {
                var y = year - i;
                $('<option value="' + y + '" >' + y + '</option>').appendTo($birthYear);
            }

            var $birthMonth = $('.gbiaps_birthday_month');
            var month = new Date().getMonth() + 1;
            //$('<option value="'+month+'" selected="selected">'+month+'</option>').appendTo($birthMonth);
            for (var m = 1; m <= 12; m++) {
                if (m == month) {
                    $('<option value="' + month + '" selected="selected">' + month + '</option>').appendTo($birthMonth);
                }
                else {
                    $('<option value="' + m + '">' + m + '</option>').appendTo($birthMonth);
                }
            }

            var $birthDay = $('.gbiaps_birthday_day');
            var day = new Date().getDate();
            //$('<option value="'+day+'" selected="selected">'+day+'</option> ').appendTo($birthDay);
            for (var d = 1; d <= 31; d++) {
                if (d == day) {
                    $('<option value="' + day + '" selected="selected">' + day + '</option> ').appendTo($birthDay);
                }
                else {
                    $('<option value="' + d + '" >' + d + '</option> ').appendTo($birthDay);
                }
            }

            $birthYear.change(onBirthChange);
            $birthMonth.change(onBirthChange);
            $birthDay.change(onBirthChange);

            function onBirthChange() {
                var year = $birthYear.find('option:selected').val();
                var month = $birthMonth.find('option:selected').val();
                var day = $birthDay.find('option:selected').val();
                //                console.log('year: '+year+' month : '+month+" day: "+day);
                switch (month - 0) {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (day > 30) {
                            setBirthDate(year, month, 30);
                        }
                        $birthDay.find('option[value="29"]').show();
                        $birthDay.find('option[value="30"]').show();
                        $birthDay.find('option[value="31"]').hide();
                        break;
                    case 2:

                        if (!isLeapYear(year)) {
                            $birthDay.find('option[value="29"]').hide();
                            if (day > 28)
                                setBirthDate(year, 2, 28);
                        } else if (day > 29) {
                            setBirthDate(year, 2, 29);
                            $birthDay.find('option[value="29"]').show();
                        }
                        //                        console.log('2');
                        $birthDay.find('option[value="30"]').hide();
                        $birthDay.find('option[value="31"]').hide();
                        break;
                    default:
                        $birthDay.find('option[value="29"]').show();
                        $birthDay.find('option[value="30"]').show();
                        $birthDay.find('option[value="31"]').show();
                        break;
                }

            }

            /**
            判断year是否闰年
            */
            function isLeapYear(year) {
                return (0 == year % 4 && (year % 100 != 0 || year % 400 == 0));
            }

            function setBirthDate(year, month, day) {
                $birthYear.val(year);
                $birthMonth.val(month);
                $birthDay.val(day);
            }

        });