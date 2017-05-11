/**
 * Created by Alex on 5/8/2017.
 */
$('.assign-station-btn').on('click',
    function() {
        var userName = $(this).attr('user-name');
        var userId = $(this).attr('user-id');
        $('#user-name').html(userName);
        $('#UserId').val(userId);
        checkIfStationIsAssigned(userId);
    });


$('.ChannelId').on('change',
    function() {
        var channelId = $(this).attr('channel-id');
        var userId = $('#UserId').val();

        if ($(this).is(":Checked")) {
            assignRemoveChannel("assign", userId, channelId);
        } else {
            assignRemoveChannel("remove", userId, channelId);
        }
    });

function assignRemoveChannel(action,userId,channelId) {
    var data = {
        UserId: userId,
        ChannelId: channelId,
        action: action
    };
    $.ajax({
        url: '/Manage/AllocateDeChannel',
        dataType: 'json',
        type:'POST',
        data:data,
        success: function(data) {

        }
});
}

function checkIfStationIsAssigned(userId) {
//    console.log($('ul#channels'));
    $.each($('.ChannelId'), function(index,element) {
        var channelId = $(element).attr('channel-id');
//        alert(channelId);
        var data = {
            UserId: userId,
            ChannelId: channelId
        };
        $.ajax({
            url: '/Manage/CheckAllocation',
            dataType: 'json',
            type: 'POST',
            data: data,
            success: function(data) {
                if (data == 'allocated') {
                    $(element).prop('checked', true);
                }
            }
        });
    });

}