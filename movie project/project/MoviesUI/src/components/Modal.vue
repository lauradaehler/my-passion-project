<template>
    <div class="modal">
        <div class="modal-content">
            <slot name="header">
                <h1>Yay</h1>
            </slot>
            <button type="button" class="button-close" v-on:click="close">
                x
            </button>

            <slot name="body">
            </slot>

            <slot name="footer">
            </slot>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Modal',
        methods: {
            close() {

            }
        }
    }
</script>

<style>
.modal {
    position: fixed;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>